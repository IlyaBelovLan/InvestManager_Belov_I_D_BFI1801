namespace InvestManager.Users.UseCases.Users.LogIn
{
    using JetBrains.Annotations;
    using MediatR;

    [UsedImplicitly]
    public class LogInQuery : IRequest<LogInResponse>
    {
        public string Email { get; set; }
        
        public string PasswordHash { get; set; }
    }
}