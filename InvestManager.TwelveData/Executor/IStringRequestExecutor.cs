namespace InvestManager.TwelveData.Executor
{
    using System.Threading.Tasks;

    /// <summary>
    /// Исполнитель строковых запросов.
    /// </summary>
    public interface IStringRequestExecutor
    {
        /// <summary>
        /// Выполняет запрос.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <returns>Результат выполнения.</returns>
        public Task<string> ExecuteAsync(string request);
    }
}