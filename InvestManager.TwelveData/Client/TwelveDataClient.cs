namespace InvestManager.TwelveData.Client
{
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Configuration;
    using Executor;
    using Json;
    using Requests.Abstractions;
    using Requests.RealTimePrice;
    using Requests.StocksList;
    using Requests.SymbolSearch;
    using Requests.TimeSeries;

    public class TwelveDataClient : ITwelveDataClient
    {
        private readonly TwelveDataConnectConfiguration _connectConfiguration;
        
        private readonly JsonSerializerOptions _serializerOptions;

        public TwelveDataClient(TwelveDataConnectConfiguration connectConfiguration)
        {
            _connectConfiguration = connectConfiguration;
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, 
                PropertyNamingPolicy = new SnakeCaseNamingPolicy()
            };
        }

        public async Task<RealTimePriceResponse> GetRealTimePriceAsync(Func<RealTimePriceRequest, RealTimePriceRequest> requestBuilder)
        {
            var request = requestBuilder(new RealTimePriceRequest(_connectConfiguration.BaseUrl, _connectConfiguration.ApiKey));
            var executeResult = await HttpGetRequestExecutor.ExecuteAsync(request.GetStringRequest()).ConfigureAwait(false);
            var response = JsonSerializer.Deserialize<RealTimePriceResponse>(executeResult, _serializerOptions);
            ThrowIfNotValid(response);
            return response;
        }

        public async Task<SymbolsSearchResponse> SearchSymbolsAsync(Func<SymbolSearchRequest, SymbolSearchRequest> requestBuilder)
        {
            var request = requestBuilder(new SymbolSearchRequest(_connectConfiguration.BaseUrl, _connectConfiguration.ApiKey));
            var executeResult = await HttpGetRequestExecutor.ExecuteAsync(request.GetStringRequest()).ConfigureAwait(false);
            var response = JsonSerializer.Deserialize<SymbolsSearchResponse>(executeResult, _serializerOptions);
            ThrowIfNotValid(response);
            return response;
        }

        public async Task<TimeSeriesResponse> GetTimeSeriesAsync(Func<TimeSeriesRequest, TimeSeriesRequest> requestBuilder)
        {
            var request = requestBuilder(new TimeSeriesRequest(_connectConfiguration.BaseUrl, _connectConfiguration.ApiKey));
            var executeResult = await HttpGetRequestExecutor.ExecuteAsync(request.GetStringRequest()).ConfigureAwait(false);
            var response = JsonSerializer.Deserialize<TimeSeriesResponse>(executeResult, _serializerOptions);
            ThrowIfNotValid(response);
            return response;
        }

        public async Task<StocksListResponse> GetStocksListAsync(Func<StocksListRequest, StocksListRequest> requestBuilder)
        {
            var request = requestBuilder(new StocksListRequest(_connectConfiguration.BaseUrl, _connectConfiguration.ApiKey));
            var executeResult = await HttpGetRequestExecutor.ExecuteAsync(request.GetStringRequest()).ConfigureAwait(false);
            var response = JsonSerializer.Deserialize<StocksListResponse>(executeResult, _serializerOptions);
            ThrowIfNotValid(response);
            return response;
        }

        private static void ThrowIfNotValid(AbstractErrorResponse response)
        {
            if (!response.IsValid)
                throw new TwelveDataException(response.Message);
        }
    }
}