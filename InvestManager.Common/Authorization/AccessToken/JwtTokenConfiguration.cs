namespace InvestManager.Common.Authorization.AccessToken
{
    public class JwtTokenConfiguration
    {
        public ExpiresInterval.ExpiresInterval ExpiresInterval { get; set; }
        
        public string SigningKey { get; set; }
    }
}