namespace InvestManager.TwelveData.Requests.Abstractions
{
    using RequestBuilder;

    /// <summary>
    /// Абстрактный запрос.
    /// </summary>
    public abstract class AbstractRequest
    {
        private readonly string _apiKey;
        
        /// <summary>
        /// <see cref="IHttpRequestBuilder"/>.
        /// </summary>
        protected IHttpRequestBuilder Builder { get; }

        protected AbstractRequest(string baseUrl, string apiKey, string endpoint)
        {
            Builder = new TwelveDataRequestBuilder(baseUrl);
            _apiKey = apiKey;
            Builder.AddEndpoint(endpoint);
        }

        /// <summary>
        /// Возвращает запрос в строкой форме.
        /// </summary>
        /// <returns>Запрос в форме строки.</returns>
        public string GetStringRequest() => Builder.AddParameter("apikey", _apiKey).Build();
    }
}