namespace InvestManager.Tests
{
    using System.Net.Http;
    using TestClient;

    public abstract class BaseTest
    {
        private static HttpClient _httpClient = new HttpClient();

        protected Client Client { get; } = new Client("https://localhost:5001", _httpClient);
    }
}
