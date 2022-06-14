namespace InvestManager.TwelveData.Requests.Common
{
    using System.ComponentModel;

    public static class IntervalExtensions
    {
        public static string ToTwelveDataFormat(this TwoPointsInterval interval)
        {
            return interval switch
            {
                TwoPointsInterval.OneMinute => "1min",
                TwoPointsInterval.FiveMinutes => "5min",
                TwoPointsInterval.FifteenMinutes => "15min",
                TwoPointsInterval.ThirtyMinutes => "30min",
                TwoPointsInterval.FortyFiveMinutes => "45min",
                TwoPointsInterval.OneHour => "1h",
                TwoPointsInterval.TwoHours => "2h",
                TwoPointsInterval.FourHours => "4h",
                TwoPointsInterval.EightHours => "8h",
                TwoPointsInterval.OneDay => "1day",
                TwoPointsInterval.OneWeek => "1week",
                TwoPointsInterval.OneMonth => "1month",
                _ => throw new InvalidEnumArgumentException($"Неизвестный интервал - {interval}!")
            };
        }
    }
}