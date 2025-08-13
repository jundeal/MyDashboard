using MyDashboardModels.MyDashboardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboardModels
{
    public class Transactions
    {
        public IEnumerable<TransactionDetail>? TransactionDetails { get; set; }
        public double Balance { get; set; }
        public double TotalGainLoss { get; set; }
    }
}
