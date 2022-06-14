namespace InvestManager.Common.Context.UserContext
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class SetUserContextPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IUserContextProvider _userContextProvider;

        public SetUserContextPipelineBehavior(IUserContextProvider userContextProvider)
        {
            _userContextProvider = userContextProvider;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is IRequestWithContext<UserContext> requestWithContext)
                requestWithContext.Context = _userContextProvider.GetContext();

            return await next().ConfigureAwait(false);
        }
    }
}