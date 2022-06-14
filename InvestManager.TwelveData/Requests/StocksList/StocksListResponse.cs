namespace InvestManager.TwelveData.Requests.StocksList
{
    using System.Collections.Generic;
    using Abstractions;

    public class StocksListResponse : AbstractErrorResponse
    {
        public IReadOnlyCollection<StocksListItem> Data { get; set; }
    }
}