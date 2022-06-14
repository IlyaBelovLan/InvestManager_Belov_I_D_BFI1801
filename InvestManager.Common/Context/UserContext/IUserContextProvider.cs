namespace InvestManager.Common.Context.UserContext
{
    public interface IUserContextProvider
    {
        public UserContext GetContext();
    }
}