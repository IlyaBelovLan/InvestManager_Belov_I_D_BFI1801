namespace InvestManager.TwelveData.Requests.SymbolSearch
{
    using Abstractions;

    public class SymbolSearchRequest : AbstractRequest
    {
        public SymbolSearchRequest(string baseUrl, string apiKey) : base(baseUrl, apiKey, "symbol_search")
        {
        }
        
        public SymbolSearchRequest BySymbol(string symbol)
        {
            Builder.AddParameter("symbol", symbol);
            return this;
        }
        
        public SymbolSearchRequest ByOutputSize(int outputSize)
        {
            Builder.AddParameter("outputsize", outputSize.ToString());
            return this;
        }
    }
}