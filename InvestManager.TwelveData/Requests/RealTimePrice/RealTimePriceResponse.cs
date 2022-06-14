namespace InvestManager.TwelveData.Requests.RealTimePrice
{
    using Abstractions;

    public class RealTimePriceResponse : AbstractErrorResponse
    {
        public string Price { get; set; }
    }
}