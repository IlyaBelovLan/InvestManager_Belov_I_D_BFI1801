namespace InvestManager.FinancialData.UseCases.GetStocksList
{
    using JetBrains.Annotations;
    using MediatR;

    [PublicAPI]
    public class GetStocksListQuery : IRequest<GetStocksListResponse>
    {
        public string Exchange { get; set; }
    }
}