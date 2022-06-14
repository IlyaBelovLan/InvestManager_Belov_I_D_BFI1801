namespace InvestManager.Tests.FinancialData.GetCurrentPrice
{
    using System.Threading.Tasks;
    using NUnit.Framework;
    using TestClient;

    public class TestUseCase : BaseTest
    {
        [Test]
        public async Task CurrentPriceIsNotNull()
        {
            var query = new GetCurrentPriceQuery { Symbol = "AAPL", Exchange = "NASDAQ" };

            var response = await Client.GetCurrentPriceAsync(query).ConfigureAwait(false);
            
            Assert.True(!string.IsNullOrEmpty(response.Price));
        }
    }
}