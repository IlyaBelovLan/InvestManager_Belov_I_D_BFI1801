namespace InvestManager.Users.UseCases.Users.LogIn
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Authorization.AccessToken.Exceptions;
    using Common.Authorization.AccessToken.Factory;
    using Database.Context;
    using JetBrains.Annotations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    [UsedImplicitly]
    public class LogInUseCase : IRequestHandler<LogInQuery, LogInResponse>
    {
        private readonly DatabaseContext _context;

        private readonly IAccessTokensFactory _tokensFactory;

        public LogInUseCase(DatabaseContext context, IAccessTokensFactory tokensFactory)
        {
            _context = context;
            _tokensFactory = tokensFactory;
        }

        public async Task<LogInResponse> Handle(LogInQuery query, CancellationToken cancellationToken)
        {
            var entityUser = await _context.Users
                .SingleOrDefaultAsync(s => s.Email == query.Email, cancellationToken).ConfigureAwait(false);

            if (entityUser == null || entityUser.PasswordHash != query.PasswordHash)
                throw new UnauthorizedException("Неверный логин или пароль!");

            return new LogInResponse
            {
                AccessToken = _tokensFactory.CreateToken(entityUser.Id, entityUser.UserName)
            };
        }
    }
}