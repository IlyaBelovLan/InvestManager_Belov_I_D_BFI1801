namespace InvestManager.FinancialData.UseCases.GetStocksList
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using JetBrains.Annotations;
    using MediatR;
    using TwelveData.Client;

    [UsedImplicitly]
    public class GetStocksListUseCase : IRequestHandler<GetStocksListQuery, GetStocksListResponse>
    {
        private readonly ITwelveDataClient _client;

        private readonly IMapper _mapper;
        
        public GetStocksListUseCase(ITwelveDataClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<GetStocksListResponse> Handle(GetStocksListQuery query, CancellationToken cancellationToken)
        {
            var response = await _client.GetStocksListAsync(r => r.ByExchange(query.Exchange)).ConfigureAwait(false);
            var stocksInfos = _mapper.Map<IReadOnlyCollection<StockInfo>>(response.Data);
            return new GetStocksListResponse { StocksInfos = stocksInfos };
        }
    }
}