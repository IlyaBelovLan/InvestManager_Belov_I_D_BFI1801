namespace InvestManager.TwelveData.Requests.SymbolSearch
{
    using System.Collections.Generic;
    using Abstractions;

    public class SymbolsSearchResponse : AbstractErrorResponse
    {
        public IReadOnlyCollection<SymbolSearchItem> Data { get; set; }
    }
}