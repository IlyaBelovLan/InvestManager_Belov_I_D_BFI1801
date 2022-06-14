namespace InvestManager.Tests.FinancialData.GetCurrentPrice
{
    using NUnit.Framework;
    using TestClient;

    public class TestValidator : BaseTest
    {
        [Test]
        public void EmptySymbolIsNotValid()
        {
            var query = new GetCurrentPriceQuery { Symbol = string.Empty };

            Assert.That(
                async () => await Client.GetCurrentPriceAsync(query).ConfigureAwait(false), 
                Throws.Exception);
        }
        
        [Test]
        public void NotExistingExchangeIsNotValid()
        {
            var query = new GetCurrentPriceQuery { Symbol = "AAPL", Exchange = "NotExistingExchange" };
            
            Assert.That(
                async () => await Client.GetCurrentPriceAsync(query).ConfigureAwait(false), 
                Throws.Exception);
        }
    }
}
