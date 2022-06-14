namespace InvestManager.Tests.FinancialData.GetPriceChart
{
    using NUnit.Framework;
    using TestClient;

    public class TestValidator :BaseTest
    {
        [Test]
        public void EmptySymbolIsNotValid()
        {
            var query = new GetPriceChartQuery() { Symbol = string.Empty };

            Assert.That(
                async () => await Client.GetPriceChartAsync(query).ConfigureAwait(false), 
                Throws.Exception);
        }
    }
}