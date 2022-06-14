namespace InvestManager.Tests.FinancialData.SearchSymbols
{
    using System.Threading.Tasks;
    using NUnit.Framework;
    using TestClient;

    public class TestUseCase : BaseTest
    {
        [Test]
        public async Task SearchResultIsNotEmpty()
        {
            var query = new SearchSymbolsQuery { Symbol = "AAPL", OutputSize = 100 };

            var response = await Client.SearchSymbolsAsync(query).ConfigureAwait(false);
            
            Assert.True(response.SymbolsCount > 0);
        }
    }
}