namespace InvestManager.FinancialData.UseCases.Common.DatePeriod
{
    using System;
    using System.ComponentModel;
    using TwelveData.Requests.Common;

    public static class Extensions
    {
        /// <summary>
        /// Вычисляет для <see cref="DatePeriod"/> подходящий интервал между двумя точками и
        /// соответствующее число вхождений интервала в период.  
        /// </summary>
        /// <param name="datePeriod">Период.</param>
        /// <returns>Интервал и число вхождений интервала.</returns>
        public static (TwoPointsInterval, int) CalculateIntervalAndNumberOccurrences(this DatePeriod datePeriod)
        {
            return datePeriod switch
            {
                DatePeriod.Day => (TwoPointsInterval.FiveMinutes , 288),
                DatePeriod.Week => (TwoPointsInterval.OneHour, 168),
                DatePeriod.Month => (TwoPointsInterval.OneDay, 31),
                DatePeriod.Year => (TwoPointsInterval.OneWeek, 52),
                DatePeriod.FiveYears => (TwoPointsInterval.OneWeek, 265),
                DatePeriod.All => (TwoPointsInterval.OneMonth, 5000),
                _ => throw new InvalidEnumArgumentException($"Неизвестный период - {datePeriod}!")
            };
        }

        public static DateTime GetStartTime(this DatePeriod datePeriod)
        {
            var nowDate = DateTime.Now.Date;
            
            return datePeriod switch
            {
                DatePeriod.Day => nowDate,
                DatePeriod.Week => nowDate.AddDays(-7),
                DatePeriod.Month => nowDate.AddMonths(-1),
                DatePeriod.Year => nowDate.AddYears(-1),
                DatePeriod.FiveYears => nowDate.AddYears(-5),
                DatePeriod.All => nowDate.AddMonths(-417),
                _ => throw new InvalidEnumArgumentException($"Неизвестный период - {datePeriod}!")
            };
        }
    }
}