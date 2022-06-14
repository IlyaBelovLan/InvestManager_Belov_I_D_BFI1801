namespace InvestManager.Users.UseCases.Notes.GetNotes
{
    using Common.Context;
    using Common.Context.UserContext;
    using JetBrains.Annotations;
    using MediatR;

    [UsedImplicitly]
    public class GetNotesQuery : IRequest<GetNotesResponse>, IRequestWithContext<UserContext>
    {
        public string Symbol { get; set; }

        UserContext IRequestWithContext<UserContext>.Context { get; set; }
    }
}