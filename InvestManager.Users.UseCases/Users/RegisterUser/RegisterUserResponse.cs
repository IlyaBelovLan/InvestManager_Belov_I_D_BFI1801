namespace InvestManager.Users.UseCases.Users.RegisterUser
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class RegisterUserResponse
    {
        public string AccessToken { get; set; }
    }
}