namespace InvestManager.TwelveData.Client.Configuration
{
    /// <summary>
    /// Конфигурация для доступа к серверу TwelveData.
    /// </summary>
    public class TwelveDataConnectConfiguration
    {
        /// <summary>
        /// Получает или задает адрес сервера.
        /// </summary>
        public string BaseUrl { get; set; }
        
        /// <summary>
        /// Получает или задает ключ для доступа к API.
        /// </summary>
        public string ApiKey { get; set; }
    }
}