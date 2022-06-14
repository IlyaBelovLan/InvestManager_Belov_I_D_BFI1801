namespace InvestManager.Tests.Users.LogIn
{
    using NUnit.Framework;
    using TestClient;

    public class TestValidator : BaseTest
    {
        [Test]
        public void WrongEmailFormatIsNotValid()
        {
            var query = new LogInQuery { Email = "WrongFormat.com", PasswordHash = "Password" };
            
            Assert.That(async () => await Client.LogInAsync(query).ConfigureAwait(false), Throws.Exception);
        }

        [Test]
        public void EmptyPasswordIsNotValid()
        {
            var query = new LogInQuery { Email = "Email@Email.com", PasswordHash = "" };
            
            Assert.That(async () => await Client.LogInAsync(query).ConfigureAwait(false), Throws.Exception);
        }
    }
}