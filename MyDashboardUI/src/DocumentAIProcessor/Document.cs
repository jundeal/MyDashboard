using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Azure;
using OpenAI.Chat;
using DocumentAIProcessor.Processors;
using System.Text.Json;
using Newtonsoft.Json.Schema.Generation;
using MyDashboardModels;

namespace DocumentAIProcessor
{
    public class Document
    {
        
        ChatClient _chatClient;
        ChatCompletionOptions _chatCompletionsOptions;

        public Document(AISettings openAISettings)
        {
            
            var openAiClient = new AzureOpenAIClient(
                    new Uri(openAISettings.OpenAIEndpoint),
                    new AzureKeyCredential(openAISettings.OpenAIKey)
                );

            _chatClient = openAiClient.GetChatClient(openAISettings.OpenAIChatModel);

            _chatCompletionsOptions = new ChatCompletionOptions
            {
                MaxOutputTokenCount = 4000,
                Temperature = 0.7f,
                ResponseFormat = ChatResponseFormat.CreateJsonObjectFormat(),
                Tools = 
                    {
                        ChatTool.CreateFunctionTool(
                            functionName: nameof(ColFinancialAccountStatement),
                            functionDescription: ColFinancialAccountStatement.Description,
                            functionParameters: BinaryData.FromString(
                                """
                                {
                                	"type": "object",
                                	"properties": {
                                		"filename": {
                                			"type": "string",
                                			"description": "The name of the file containing the financial account statement."
                                		}
                                	},
                                	"required": [
                                		"filename"
                                	]
                                } 
                                """)

                        )
                    }
               
            };

        }

        private string GetToolChatContent(ChatToolCall toolCall)
        {
            if (toolCall.FunctionName == nameof(ColFinancialAccountStatement))
            {
                using JsonDocument argumentDocument = JsonDocument.Parse(toolCall.FunctionArguments);
                if ((argumentDocument.RootElement.TryGetProperty("filename", out JsonElement filenameElement)))
                {
                    var colFinancialAccountStatement = new ColFinancialAccountStatement();
                    return "Data:" + colFinancialAccountStatement.GetContent(filenameElement.GetString()) +  "\n" +
                            "Instructions: " + colFinancialAccountStatement.GetInstructions() + "\n" +
                            "Output Format:" + colFinancialAccountStatement.GetOutputFormat();
                }
            }

            return null;
        }

        public async Task<string> ProcessDocumentAsync(string filename, string description)
        {
            var request = $"Get the filename {filename} for {description}";

            List<ChatMessage> messages =
                [
                    new UserChatMessage(request),
                    new UserChatMessage("Response in Json format.")
                ];

            var response = _chatClient.CompleteChat(messages, _chatCompletionsOptions);

            while (response.Value.FinishReason == ChatFinishReason.ToolCalls)
            {
                messages.Add(new AssistantChatMessage(response));

                foreach (var toolCall in response.Value.ToolCalls)
                {
                    messages.Add(new ToolChatMessage(toolCall.Id, GetToolChatContent(toolCall)));
                    
                }

                response = _chatClient.CompleteChat(messages, _chatCompletionsOptions);
            }

            return response.Value.Content[0].Text;  // .Choices[0].Message.Content;
        }



    }
}
