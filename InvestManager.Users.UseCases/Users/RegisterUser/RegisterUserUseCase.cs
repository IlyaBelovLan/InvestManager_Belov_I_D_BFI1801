namespace InvestManager.Users.UseCases.Users.RegisterUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common.Authorization.AccessToken.Factory;
    using Common.Exceptions;
    using Database.Context;
    using Database.Models;
    using JetBrains.Annotations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    [UsedImplicitly]
    public class RegisterUserUseCase : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly DatabaseContext _context;

        private readonly IAccessTokensFactory _tokensFactory;

        private readonly IMapper _mapper;

        public RegisterUserUseCase(DatabaseContext context, IAccessTokensFactory tokensFactory, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _tokensFactory = tokensFactory;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var entityUser = _mapper.Map<EntityUser>(command);
            var entry = await _context.Users.AddAsync(entityUser, cancellationToken).ConfigureAwait(false);

            if (entry.State != EntityState.Added)
                throw new UseCaseException("При регистрации пользователя произошла ошибка!");

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            var accessToken = _tokensFactory.CreateToken(entityUser.Id, entityUser.UserName);
            return new RegisterUserResponse { AccessToken = accessToken };
        }
    }
}