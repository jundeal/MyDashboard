using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboardModels
{
    public class Stocks
    {
        public IEnumerable<StockPosition>? StockPositions { get; set; }
        public double TotalCost { get; set; }
        public double TotalMarketValue { get; set; }
        public double TotalGainLoss { get; set; }
    }

    public class StockPosition
    {
        public string Security { get; set; } = string.Empty;
        public double BegingShares { get; set; }
        public double EndingShares { get; set; }
        public double CurrentShares { get; set; }
        public double Cost { get; set; }
        public double AverageCost { get; set; }
        public double CurrentMarketPrice { get; set; }
        public double MarketValue { get; set; }
        public double GainLoss { get; set; }
    }
}
