namespace InvestManager.Tests.Users.RegisterUser
{
    using NUnit.Framework;
    using TestClient;

    public class TestValidator : BaseTest
    {
        [Test]
        public void EmptyUserNameIsNotValid()
        {
            var command = new RegisterUserCommand { UserName = "", Email = "Email@Email.com", PasswordHash = "Password" };
            
            Assert.That(async () => await Client.RegisterUserAsync(command).ConfigureAwait(false), Throws.Exception);
        }
        
        [Test]
        public void WrongEmailFormatIsNotValid()
        {
            var command = new RegisterUserCommand { UserName = "NewUser", Email = "WrongFormat.com", PasswordHash = "Password" };
            
            Assert.That(async () => await Client.RegisterUserAsync(command).ConfigureAwait(false), Throws.Exception);
        }

        [Test]
        public void EmptyPasswordIsNotValid()
        {
            var command = new RegisterUserCommand { UserName = "NewUser", Email = "Email@Email.com", PasswordHash = "" };
            
            Assert.That(async () => await Client.RegisterUserAsync(command).ConfigureAwait(false), Throws.Exception);
        }
    }
}