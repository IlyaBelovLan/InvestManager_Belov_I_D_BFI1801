namespace InvestManager.Common.Context
{
    public static class Extensions
    {
        public static TContext GetContext<TContext>(this IRequestWithContext<TContext> request) => request.Context;
    }
}