namespace InvestManager.FinancialData.UseCases.GetPriceChart
{
    using AutoMapper;
    using InvestManager.Common.Mapping;
    using JetBrains.Annotations;
    using TwelveData.Requests.TimeSeries;

    [UsedImplicitly]
    public class GetPriceChartMapping : Profile
    {
        public GetPriceChartMapping()
        {
            CreateMap<TimeSeriesItem, PriceChartItem>();
            
            CreateMap<TimeSeriesResponse, GetPriceChartResponse>()
                .ForMemberFrom(d => d.Currency, s => s.Meta.Currency)
                .ForMemberFrom(d => d.ExchangeTimezone, s => s.Meta.ExchangeTimezone)
                .ForMemberFrom(d => d.InstrumentType, s => s.Meta.Type)
                .ForMemberFrom(d => d.ChartItems, s => s.Values)
                .ForMemberFrom(d => d.ItemsCount, s => s.Values.Count);
        }
    }
}