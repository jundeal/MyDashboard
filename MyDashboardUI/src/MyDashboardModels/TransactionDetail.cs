namespace MyDashboardModels
{
    namespace MyDashboardModels
    {
        public class TransactionDetail
        {
            public DateTime TransactionDate { get; set; }
            public string TransactionType { get; set; } = string.Empty;
            public string ReferenceNumber { get; set; } = string.Empty;
            public string Security { get; set; } = string.Empty;
            public double Shares { get; set; }
            public double PricePerShare { get; set; }
            public double GrossAmount { get; set; }
            public double CommisionAndVat { get; set; }
            public double OtherCharges { get; set; }
            public double NetAmount { get; set; }
            public double Balance { get; set; }
            public double Cost { get; set; }
            public double GainLoss { get; set; }
            public string TransactionDescription { get; set; } = string.Empty;
            public double TransactionAmount { get; set; }
        }
    }
}
