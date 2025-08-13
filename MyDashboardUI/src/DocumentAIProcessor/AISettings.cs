using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentAIProcessor
{
    public class AISettings
    {
        public string OpenAIEndpoint { get; }= string.Empty;
        public string OpenAIChatModel { get; } = string.Empty;
        public string OpenAIKey { get; } = string.Empty;
    }
}
