namespace InvestManager.Tests.FinancialData.GetStocksList
{
    using NUnit.Framework;
    using TestClient;

    public class TestValidator : BaseTest
    {
        [Test]
        public void EmptyExchangeIsNotValid()
        {
            var query = new GetStocksListQuery { Exchange = string.Empty };
            
            Assert.That(async () => await Client.GetStocksListAsync(query).ConfigureAwait(false), Throws.Exception);
        }
    }
}