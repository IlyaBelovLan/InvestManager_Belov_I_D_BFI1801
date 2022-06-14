namespace InvestManager.TwelveData.RequestBuilder
{
    /// <summary>
    /// Строитель запросов.
    /// </summary>
    public interface IHttpRequestBuilder
    {
        /// <summary>
        /// Добавляет конечную точку в запрос.
        /// </summary>
        /// <param name="endpoint">Конечная точка.</param>
        /// <returns><see cref="IHttpRequestBuilder"/>.</returns>
        public IHttpRequestBuilder AddEndpoint(string endpoint);

        /// <summary>
        /// Добавляет параметр.
        /// </summary>
        /// <param name="parameterName">Имя параметра.</param>
        /// <param name="parameterValue">Значение параметра.</param>
        /// <returns></returns>
        public IHttpRequestBuilder AddParameter(string parameterName, string parameterValue);

        /// <summary>
        /// Возвращает готовый запрос.
        /// </summary>
        /// <returns>Запрос.</returns>
        public string Build();
    }
}