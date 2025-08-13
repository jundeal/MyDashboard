using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboardModels
{
    public class StocksMonthlyStatement
    {
        public string FirmName { get; set; }=string.Empty;
        public string ReportGenerationDate { get; set; } = string.Empty;
        public string AsOf { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public double TotalEquity { get; set; }

        public Transactions? Transactions { get; set; }
        public IEnumerable<Stocks>? Stocks { get; set; }
    }

    
}
