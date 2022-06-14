namespace InvestManager.Tests.Notes
{
    using System.Threading.Tasks;
    using Common;
    using NUnit.Framework;
    using TestClient;

    public abstract class TestWithAuthorization : BaseTest
    {
        [OneTimeSetUp]
        public async Task SetUpAccessToken()
        {
            var accessToken = await RegisterUser().ConfigureAwait(false);
            Client.SetAccessToken(accessToken);
        }
        protected async Task<string> RegisterUser()
        {
            var userName = Helper.CreateRandomString(16);
            var email = $"{Helper.CreateRandomString(8)}@{Helper.CreateRandomString(8)}.com";
            var password = Helper.CreateRandomString(16);
           
            var command = new RegisterUserCommand
            {
                UserName = userName,
                Email = email,
                PasswordHash = password
            };

            var response = await Client.RegisterUserAsync(command).ConfigureAwait(false);

            return response.AccessToken;
        }
    }
}