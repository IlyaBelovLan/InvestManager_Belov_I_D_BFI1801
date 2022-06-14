namespace InvestManager.TwelveData.Requests.TimeSeries
{
    using Common;

    public class Meta
    {
        public string Symbol { get; set; }
        
        public TwoPointsInterval Interval { get; set; }

        public string Currency { get; set; }
        
        public string ExchangeTimezone { get; set; }
        
        public string Exchange { get; set; }
        
        public string Type { get; set; }
    }
}