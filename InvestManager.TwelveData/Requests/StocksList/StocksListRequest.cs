namespace InvestManager.TwelveData.Requests.StocksList
{
    using Abstractions;

    public class StocksListRequest : AbstractRequest
    {
        public StocksListRequest(string baseUrl, string apiKey) : base(baseUrl, apiKey, "/stocks")
        {
        }
        
        public StocksListRequest ByExchange(string exchange)
        {
            Builder.AddParameter("exchange", exchange);
            return this;
        }
    }
}