namespace InvestManager.Users.UseCases.Notes.CreateNote
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Context;
    using Common.Context.UserContext;
    using Common.Exceptions;
    using Database.Context;
    using Database.Models;
    using JetBrains.Annotations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    [UsedImplicitly]
    public class CreateNoteUseCase : IRequestHandler<CreateNoteCommand>
    {
        private readonly DatabaseContext _context;

        public CreateNoteUseCase(DatabaseContext context) => _context = context;

        public async Task<Unit> Handle(CreateNoteCommand command, CancellationToken cancellationToken)
        {
            var userContext = command.GetContext<UserContext>();
            var entityUser = await _context.Users
                .FirstAsync(w => w.Id == Convert.ToInt64(userContext.UserId), cancellationToken).ConfigureAwait(false);

            var entityNote = new EntityNote
            {
                EntityUserId = entityUser.Id, 
                Symbol = command.Symbol, 
                Text = command.Text,
                CreateDate = DateTime.Now
            };
            
            var entry = await _context.Notes
                .AddAsync(entityNote, cancellationToken).ConfigureAwait(false);

            if (entry.State != EntityState.Added)
                throw new UseCaseException("При создании заметки произошла ошибка!");
            
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            
            return Unit.Value;
        }
    }
}