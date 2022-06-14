namespace InvestManager.FinancialData.UseCases.GetPriceChart
{
    using System.Collections.Generic;
    using JetBrains.Annotations;

    [PublicAPI]
    public class GetPriceChartResponse
    {
        public string Currency { get; set; }
        
        public string ExchangeTimezone { get; set; }
        
        public string InstrumentType { get; set; }
        
        public IReadOnlyCollection<PriceChartItem> ChartItems { get; set; }
        
        public int ItemsCount { get; set; }
    }
}