namespace InvestManager.TwelveData.Requests.Abstractions
{
    public abstract class AbstractErrorResponse
    {
        public int? Code { get; set; }
        
        public string Message { get; set; }
        
        public bool IsValid => Code == null;
    }
}