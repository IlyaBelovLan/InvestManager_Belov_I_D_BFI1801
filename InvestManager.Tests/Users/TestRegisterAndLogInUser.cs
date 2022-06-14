namespace InvestManager.Tests.Users
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Threading.Tasks;
    using Common;
    using NUnit.Framework;
    using TestClient;
    using WebApi.Infrastructure.Authorization;

    public class TestRegisterAndLogInUser : BaseTest
    {
        // TODO: а не брать ли нам этот ключик из конфигурации?
        private static string _signingKeyFromConfiguration = "1234567891234567";
        
        [Test]
        public async Task RegisterAndLogInUser()
        {
            var userName = Helper.CreateRandomString(16);
            var email = $"{Helper.CreateRandomString(8)}@{Helper.CreateRandomString(8)}.com";
            var password = Helper.CreateRandomString(16);

            await TestRegister(userName, email, password);
            await TestLogIn(email, password);
            
            Assert.Pass();
        }

        private async Task TestRegister(string userName, string email, string password)
        {
            var registerCommand = new RegisterUserCommand
            {
                UserName = userName,
                Email = email,
                PasswordHash = password
            };

            var registerResponse = await Client.RegisterUserAsync(registerCommand).ConfigureAwait(false);
            WillThrowIfTokenIsNotValid(registerResponse.AccessToken);
        }

        private async Task TestLogIn(string email, string password)
        {
            var logInQuery = new LogInQuery
            {
                Email = email,
                PasswordHash = password
            };

            var logInResponse = await Client.LogInAsync(logInQuery).ConfigureAwait(false);
            WillThrowIfTokenIsNotValid(logInResponse.AccessToken);
        }

        private static void WillThrowIfTokenIsNotValid(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.ValidateToken(token, AuthorizationParameters.GetTokenValidationParameters(_signingKeyFromConfiguration), out _);
        }
    }
}