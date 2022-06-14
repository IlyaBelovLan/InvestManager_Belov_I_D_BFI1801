namespace InvestManager.TwelveData.Requests.RealTimePrice
{
    using Abstractions;

    /// <summary>
    /// Запрос получения цены в реальном времени.
    /// </summary>
    public class RealTimePriceRequest : AbstractRequest
    {
        public RealTimePriceRequest(string baseUrl,string apiKey) : base(baseUrl, apiKey, "price")
        {
        }
        
        /// <summary>
        /// Устанавливает параметр Symbol.
        /// </summary>
        /// <param name="symbol">Значение параметра.</param>
        /// <returns><see cref="RealTimePriceRequest"/>.</returns>
        public RealTimePriceRequest BySymbol(string symbol)
        {
            Builder.AddParameter("symbol", symbol);
            return this;
        }

        public RealTimePriceRequest ByExchange(string exchange)
        {
            Builder.AddParameter("exchange", exchange);
            return this;
        }
        
        public RealTimePriceRequest ByCountry(string country)
        {
            Builder.AddParameter("country", country);
            return this;
        }
    }
}