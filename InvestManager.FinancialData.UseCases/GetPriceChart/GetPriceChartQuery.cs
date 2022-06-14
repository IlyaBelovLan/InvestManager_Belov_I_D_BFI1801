namespace InvestManager.FinancialData.UseCases.GetPriceChart
{
    using Common.DatePeriod;
    using JetBrains.Annotations;
    using MediatR;

    [PublicAPI]
    public class GetPriceChartQuery : IRequest<GetPriceChartResponse>
    {
        public string Symbol { get; set; }
        
        public string Exchange { get; set; }
        
        public DatePeriod DatePeriod { get; set; }
    }
}