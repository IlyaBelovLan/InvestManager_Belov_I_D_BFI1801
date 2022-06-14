namespace InvestManager.Users.UseCases.Users.RegisterUser
{
    using JetBrains.Annotations;
    using MediatR;

    [PublicAPI]
    public class RegisterUserCommand : IRequest<RegisterUserResponse>
    {
        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public string PasswordHash { get; set; }
    }
}