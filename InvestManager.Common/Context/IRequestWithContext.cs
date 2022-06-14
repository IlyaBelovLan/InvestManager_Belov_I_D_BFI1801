namespace InvestManager.Common.Context
{
    public interface IRequestWithContext<TContext>
    {
        public TContext Context { get; set; }
    }
}