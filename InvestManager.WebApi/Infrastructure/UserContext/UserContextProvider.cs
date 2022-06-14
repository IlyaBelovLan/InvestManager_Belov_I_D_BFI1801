namespace InvestManager.WebApi.Infrastructure.UserContext
{
    using Common.Authorization.AccessToken;
    using Common.Context.UserContext;
    using Microsoft.AspNetCore.Http;

    public class UserContextProvider : IUserContextProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextProvider(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;

        public UserContext GetContext()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserId).Value ?? string.Empty;
            return new UserContext { UserId = userId };
        }
    }
}