namespace InvestManager.FinancialData.UseCases.GetCurrentPrice
{
    using JetBrains.Annotations;
    using MediatR;

    [PublicAPI]
    public class GetCurrentPriceQuery : IRequest<GetCurrentPriceResponse>
    {
        public string Symbol { get; set; }
        
        public string Exchange { get; set; }
    }
}