namespace InvestManager.TwelveData.RequestBuilder
{
    using System.Text;

    /// <summary>
    /// Строитель запросов для TwelveData.
    /// </summary>
    public class TwelveDataRequestBuilder : IHttpRequestBuilder
    {
        /// <summary>
        /// <see cref="StringBuilder"/>.
        /// </summary>
        private readonly StringBuilder _builder;

        /// <summary>
        /// Счетчик параметров.
        /// </summary>
        private int _parametersCount;
        
        /// <summary>
        /// Получает символ разделитель для параметров в зависимости от числа параметров.
        /// </summary>
        private char ParametersSeparator => _parametersCount == 0 ? '?' : '&';
        
        public TwelveDataRequestBuilder(string baseUrl)
        {
            _builder = new StringBuilder(baseUrl);
            _parametersCount = 0;
        }

        /// <inheritdoc />
        public IHttpRequestBuilder AddEndpoint(string endpoint)
        {
            var trimmedEndpoint = endpoint.Trim().Trim('/');
            _builder.Append($"/{trimmedEndpoint}");
            return this;
        }

        /// <inheritdoc />
        public IHttpRequestBuilder AddParameter(string parameterName, string parameterValue)
        {
            _builder.Append($"{ParametersSeparator}{parameterName}={parameterValue}");
            _parametersCount++;
            return this;
        }

        /// <inheritdoc />
        public string Build()
        {
            return _builder.ToString();
        }
    }
}