namespace InvestManager.FinancialData.UseCases.SearchSymbols
{
    using System.Collections.Generic;
    using JetBrains.Annotations;

    [PublicAPI]
    public class SearchSymbolsResponse
    {
        public IReadOnlyCollection<SearchSymbolsResponseItem> Data { get; set; }
        
        public int SymbolsCount { get; set; }
    }
}