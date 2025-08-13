using MyDashboardModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace DocumentAIProcessor.Processors
{
    internal class DocumentProcessor
    {
        public static string Description => "This processor analyzes documents and extracts key information such as entities, summaries, and other relevant data.";

        public string InstructionsFile { get; set; } = string.Empty;
        public virtual string GetContent(string filename)
        {
            return File.ReadAllText(filename);
        }

        public virtual string GetInstructions()
        {
            return File.ReadAllText(InstructionsFile);
        }

        public virtual string GetOutputFormat()
        {
            var jsonFormat = new StocksMonthlyStatement();
            
            var jsonSettings = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy() 
            };

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = jsonSettings,
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(jsonFormat, jsonSerializerSettings); 
        }
    }
}
