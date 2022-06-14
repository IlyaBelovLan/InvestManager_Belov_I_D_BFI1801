namespace InvestManager.FinancialData.UseCases.SearchSymbols
{
    using AutoMapper;
    using JetBrains.Annotations;
    using TwelveData.Requests.SymbolSearch;

    [UsedImplicitly]
    public class SearchSymbolsMapping : Profile
    {
        public SearchSymbolsMapping()
        {
            CreateMap<SymbolSearchItem, SearchSymbolsResponseItem>();
            
            CreateMap<SymbolsSearchResponse, SearchSymbolsResponse>()
                .ForMember(d => d.SymbolsCount, o => o.MapFrom(s => s.Data.Count));
        }
    }
}