namespace InvestManager.Tests.FinancialData.GetPriceChart
{
    using System.Threading.Tasks;
    using NUnit.Framework;
    using TestClient;

    public class TestUseCase : BaseTest
    {
        [Test]
        public async Task ChartItemsIsNotEmpty()
        {
            var query = new GetPriceChartQuery
            {
                Symbol = "AAPL", 
                Exchange = "NASDAQ",
                DatePeriod = DatePeriod.Week
            };

            var response = await Client.GetPriceChartAsync(query).ConfigureAwait(false);

            Assert.True(response.ItemsCount > 0);
        }
    }
}