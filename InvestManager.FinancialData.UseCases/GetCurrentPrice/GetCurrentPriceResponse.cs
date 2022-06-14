namespace InvestManager.FinancialData.UseCases.GetCurrentPrice
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class GetCurrentPriceResponse
    {
        public string Price { get; set; }
    }
}