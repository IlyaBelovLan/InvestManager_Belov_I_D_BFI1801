namespace InvestManager.TwelveData.Requests.Common
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum TwoPointsInterval
    { 
        [EnumMember(Value = "1min")]
        OneMinute, 
        
        [EnumMember(Value = "5min")]
        FiveMinutes, 
        
        [EnumMember(Value = "15min")]
        FifteenMinutes, 
        
        [EnumMember(Value = "30min")]
        ThirtyMinutes, 
        
        [EnumMember(Value = "45min")]
        FortyFiveMinutes, 
        
        [EnumMember(Value = "1h")]
        OneHour, 
        
        [EnumMember(Value = "2h")]
        TwoHours, 
        
        [EnumMember(Value = "4h")]
        FourHours, 
        
        [EnumMember(Value = "8h")]
        EightHours,
        
        [EnumMember(Value = "1day")]
        OneDay, 
        
        [EnumMember(Value = "1week")]
        OneWeek, 
        
        [EnumMember(Value = "1month")]
        OneMonth
    }
}