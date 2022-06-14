namespace InvestManager.Tests.FinancialData.GetStocksList
{
    using System.Linq;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using TestClient;

    public class TestUseCase : BaseTest
    {
        [Test]
        public async Task InputExchangeIsEqualOutputExchange()
        {
            var exchange = "NASDAQ";
            var query = new GetStocksListQuery { Exchange = exchange };

            var response = await Client.GetStocksListAsync(query).ConfigureAwait(false);

            Assert.True(response.StocksInfos.All(i => i.Exchange == exchange));
        }
    }
}