namespace InvestManager.TwelveData.Client.Factory
{
    using Configuration;

    public class TwelveDataClientFactory : ITwelveDataClientFactory
    {
        private readonly TwelveDataConnectConfiguration _connectConfiguration;

        public TwelveDataClientFactory(TwelveDataConnectConfiguration connectConfiguration) => _connectConfiguration = connectConfiguration;

        public ITwelveDataClient Create() =>
            new TwelveDataClient(_connectConfiguration);
    }
}