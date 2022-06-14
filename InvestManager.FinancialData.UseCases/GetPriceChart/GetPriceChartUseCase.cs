namespace InvestManager.FinancialData.UseCases.GetPriceChart
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common.DatePeriod;
    using JetBrains.Annotations;
    using MediatR;
    using TwelveData.Client;

    [UsedImplicitly]
    public class GetPriceChartUseCase : IRequestHandler<GetPriceChartQuery, GetPriceChartResponse>
    {
        private readonly ITwelveDataClient _client;

        private readonly IMapper _mapper;

        public GetPriceChartUseCase(ITwelveDataClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<GetPriceChartResponse> Handle(GetPriceChartQuery query, CancellationToken cancellationToken)
        {
            var (interval, outputSize) = query.DatePeriod.CalculateIntervalAndNumberOccurrences();
            var response = await _client.GetTimeSeriesAsync(r => r
                .BySymbol(query.Symbol)
                .ByExchange(query.Exchange)
                .ByInterval(interval)
                .ByOutputSize(outputSize)
                .ByStartDate(query.DatePeriod.GetStartTime()));

            return _mapper.Map<GetPriceChartResponse>(response);
        }
    }
}