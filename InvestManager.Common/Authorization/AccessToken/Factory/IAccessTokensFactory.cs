namespace InvestManager.Common.Authorization.AccessToken.Factory
{
    public interface IAccessTokensFactory
    {
        public string CreateToken(long userId, string userName);
    }
}