namespace InvestManager.Tests.FinancialData.SearchSymbols
{
    using NUnit.Framework;
    using TestClient;

    public class TestValidator : BaseTest
    {
        [Test]
        public void EmptySymbolIsNotValid()
        {
            var query = new SearchSymbolsQuery { Symbol = string.Empty, OutputSize = 100 };

            Assert.That(async () => await Client.SearchSymbolsAsync(query).ConfigureAwait(false), Throws.Exception);
        }
        
        [Test]
        public void LessThenNullOutputSizeIsNotValid()
        {
            var query = new SearchSymbolsQuery { Symbol = "AAPL", OutputSize = -1 };

            Assert.That(async () => await Client.SearchSymbolsAsync(query).ConfigureAwait(false), Throws.Exception);
        }
    }
}