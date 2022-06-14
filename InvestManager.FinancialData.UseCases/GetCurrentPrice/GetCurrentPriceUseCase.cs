namespace InvestManager.FinancialData.UseCases.GetCurrentPrice
{
    using System.Threading;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using MediatR;
    using TwelveData.Client;

    [UsedImplicitly]
    public class GetCurrentPriceUseCase : IRequestHandler<GetCurrentPriceQuery, GetCurrentPriceResponse>
    {
        private readonly ITwelveDataClient _client;

        public GetCurrentPriceUseCase(ITwelveDataClient client) => _client = client;

        public async Task<GetCurrentPriceResponse> Handle(GetCurrentPriceQuery query, CancellationToken cancellationToken)
        {
            var response = await _client.GetRealTimePriceAsync(r => r
                    .BySymbol(query.Symbol)
                    .ByExchange(query.Exchange)).ConfigureAwait(false);

            return new GetCurrentPriceResponse { Price = response.Price };
        }
    }
}