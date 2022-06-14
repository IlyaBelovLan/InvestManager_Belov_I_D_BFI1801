namespace InvestManager.TwelveData.Client
{
    using System;
    using System.Threading.Tasks;
    using Requests.RealTimePrice;
    using Requests.StocksList;
    using Requests.SymbolSearch;
    using Requests.TimeSeries;

    public interface ITwelveDataClient
    {
        public Task<RealTimePriceResponse> GetRealTimePriceAsync(Func<RealTimePriceRequest, RealTimePriceRequest> requestBuilder);
        
        public Task<SymbolsSearchResponse> SearchSymbolsAsync(Func<SymbolSearchRequest, SymbolSearchRequest> requestBuilder);
        
        public Task<TimeSeriesResponse> GetTimeSeriesAsync(Func<TimeSeriesRequest, TimeSeriesRequest> requestBuilder);
        
        public Task<StocksListResponse> GetStocksListAsync(Func<StocksListRequest, StocksListRequest> requestBuilder);
    }
}