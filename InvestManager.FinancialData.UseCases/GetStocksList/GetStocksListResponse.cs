namespace InvestManager.FinancialData.UseCases.GetStocksList
{
    using System.Collections.Generic;
    using JetBrains.Annotations;

    [PublicAPI]
    public class GetStocksListResponse
    {
        public IReadOnlyCollection<StockInfo> StocksInfos { get; set; }
    }
}