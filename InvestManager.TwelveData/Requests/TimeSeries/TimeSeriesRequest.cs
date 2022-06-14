namespace InvestManager.TwelveData.Requests.TimeSeries
{
    using System;
    using Abstractions;
    using Common;

    public class TimeSeriesRequest : AbstractRequest
    {
        public TimeSeriesRequest(string baseUrl, string apiKey) : base(baseUrl, apiKey, "time_series")
        {
        }

        public TimeSeriesRequest BySymbol(string symbol)
        {
            Builder.AddParameter("symbol", symbol);
            return this;
        }

        public TimeSeriesRequest ByInterval(TwoPointsInterval interval)
        {
            Builder.AddParameter("interval", interval.ToTwelveDataFormat());
            return this;
        }
        
        public TimeSeriesRequest ByExchange(string exchange)
        {
            Builder.AddParameter("exchange", exchange);
            return this;
        }
        
        public TimeSeriesRequest ByCountry(string country)
        {
            Builder.AddParameter("country", country);
            return this;
        }
        
        public TimeSeriesRequest ByOutputSize(int outputSize)
        {
            Builder.AddParameter("outputsize", outputSize.ToString());
            return this;
        }

        public TimeSeriesRequest ByStartDate(DateTime dateTime)
        {
            var stringDateTime = dateTime.ToString("yyyy-MM-dd hh:mm:ss");
            Builder.AddParameter("start_date", stringDateTime);
            return this;
        }
    }
}