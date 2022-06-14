namespace InvestManager.FinancialData.UseCases.GetStocksList
{
    using AutoMapper;
    using JetBrains.Annotations;
    using TwelveData.Requests.StocksList;

    [UsedImplicitly]
    public class GetStocksListMapping : Profile
    {
        public GetStocksListMapping()
        {
            CreateMap<StocksListItem, StockInfo>();
        }
    }
}