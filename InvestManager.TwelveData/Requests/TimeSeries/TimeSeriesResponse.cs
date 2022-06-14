namespace InvestManager.TwelveData.Requests.TimeSeries
{
    using System.Collections.Generic;
    using Abstractions;

    public class TimeSeriesResponse : AbstractErrorResponse
    {
        public Meta Meta { get; set; }
        
        public IReadOnlyCollection<TimeSeriesItem> Values { get; set; }
    }
}