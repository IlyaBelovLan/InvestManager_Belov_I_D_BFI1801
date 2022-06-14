namespace InvestManager.FinancialData.UseCases.SearchSymbols
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using JetBrains.Annotations;
    using MediatR;
    using TwelveData.Client;

    [UsedImplicitly]
    public class SearchSymbolsUseCase : IRequestHandler<SearchSymbolsQuery, SearchSymbolsResponse>
    {
        private readonly ITwelveDataClient _client;

        private readonly IMapper _mapper;

        public SearchSymbolsUseCase(ITwelveDataClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<SearchSymbolsResponse> Handle(SearchSymbolsQuery query, CancellationToken cancellationToken)
        {
            var response = await _client.SearchSymbolsAsync(r => r
                    .BySymbol(query.Symbol)
                    .ByOutputSize(query.OutputSize)).ConfigureAwait(false);

            return _mapper.Map<SearchSymbolsResponse>(response);
        }
    }
}