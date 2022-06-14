namespace InvestManager.TwelveData.Requests.SymbolSearch
{
    public class SymbolSearchItem
    {
        public string Symbol { get; set; }
        
        public string InstrumentName { get; set; }
        
        public string Exchange { get; set; }
        
        public string ExchangeTimezone { get; set; }
        
        public string InstrumentType { get; set; }
        
        public string Country { get; set; }
        
        public string Currency { get; set; }
    }
}