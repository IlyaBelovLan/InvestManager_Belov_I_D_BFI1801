namespace InvestManager.Common.Authorization.AccessToken.Factory
{
    public class JwtTokensFactory : IAccessTokensFactory
    {
        private readonly JwtTokenConfiguration _configuration;

        public JwtTokensFactory(JwtTokenConfiguration configuration) => _configuration = configuration;

        public string CreateToken(long userId, string userName) => JwtHelper.CreateJwtToken(_configuration, userId, userName);
    }
}