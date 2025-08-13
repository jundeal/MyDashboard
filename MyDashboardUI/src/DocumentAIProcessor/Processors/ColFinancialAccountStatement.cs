using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentAIProcessor.Processors
{
    internal class ColFinancialAccountStatement : DocumentProcessor
    {
        public static new string Description => "This processor analyzes financial account statements from COL Financial and extracts key information such as account details, transaction history, and balances.";

        public ColFinancialAccountStatement()
        {
            InstructionsFile = @".\ProcessingInstructions\ColFinancialStatementInstructions.txt";
        }
    }
    
}
