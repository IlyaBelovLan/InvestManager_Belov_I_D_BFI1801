namespace InvestManager.Common.Authorization.AccessToken.ExpiresInterval
{
    using System;
    using System.ComponentModel;

    public static class ExpiresIntervalExtensions
    {
        public static TimeSpan ToTimeSpan(this ExpiresInterval interval)
        {
            return interval switch
            {
                ExpiresInterval.OneMinute => TimeSpan.FromMinutes(1),
                ExpiresInterval.OneHour => TimeSpan.FromHours(1),
                _ => throw new InvalidEnumArgumentException($"Неизвестный интервал истечения - {interval}!")
            };
        }
    }
}