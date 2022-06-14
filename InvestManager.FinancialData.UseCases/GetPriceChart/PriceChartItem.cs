namespace InvestManager.FinancialData.UseCases.GetPriceChart
{
    public class PriceChartItem
    {
        public string Datetime { get; set; }
        
        public string Open { get; set; }
        
        public string High { get; set; }
        
        public string Low { get; set; }
        
        public string Close { get; set; }
        
        public string Volume { get; set; }
    }
}