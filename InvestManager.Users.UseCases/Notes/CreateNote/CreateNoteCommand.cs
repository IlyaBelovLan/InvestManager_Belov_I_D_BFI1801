namespace InvestManager.Users.UseCases.Notes.CreateNote
{
    using Common.Context;
    using Common.Context.UserContext;
    using JetBrains.Annotations;
    using MediatR;

    [PublicAPI]
    public class CreateNoteCommand : IRequest, IRequestWithContext<UserContext>
    {
        public string Symbol { get; set; }
        
        public string Text { get; set; }
        
        UserContext IRequestWithContext<UserContext>.Context { get; set; }
    }
}