namespace InvestManager.TwelveData.Executor
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Исполнитель Get-запросов.
    /// </summary>
    public static class HttpGetRequestExecutor
    {
        /// <summary>
        /// <see cref="HttpClient"/>.
        /// </summary>
        private static readonly HttpClient Client = new HttpClient();
        
        public static async Task<string> ExecuteAsync(string request)
        {
            var response = await Client.GetAsync(request).ConfigureAwait(false);
            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return responseBody;
        }
    }
}