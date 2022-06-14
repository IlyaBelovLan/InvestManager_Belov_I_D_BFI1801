namespace InvestManager.FinancialData.UseCases.SearchSymbols
{
    using JetBrains.Annotations;
    using MediatR;

    [PublicAPI]
    public class SearchSymbolsQuery : IRequest<SearchSymbolsResponse>
    {
        public string Symbol { get; set; }
        
        public int OutputSize { get; set; }
    }
}