namespace InvestManager.Users.UseCases.Notes.GetNotes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common.Context;
    using Common.Context.UserContext;
    using Common.Extensions;
    using Database.Context;
    using JetBrains.Annotations;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    [UsedImplicitly]
    public class GetNotesUseCase : IRequestHandler<GetNotesQuery, GetNotesResponse>
    {
        private readonly DatabaseContext _context;

        private readonly IMapper _mapper;

        public GetNotesUseCase(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetNotesResponse> Handle(GetNotesQuery query, CancellationToken cancellationToken)
        {
            var userContext = query.GetContext<UserContext>();
            var userId = Convert.ToInt64(userContext.UserId);

            var allSatisfyingEntityNotes = await _context.Notes
                .Where(w => w.EntityUserId == userId)
                .Where(w => query.Symbol.IsNullOrEmpty() || w.Symbol == query.Symbol)
                .ToListAsync(cancellationToken).ConfigureAwait(false);
            
            return new GetNotesResponse
            {
                Notes = _mapper.Map<IReadOnlyCollection<Note>>(allSatisfyingEntityNotes),
                Count = allSatisfyingEntityNotes.Count,
            };
        }
    }
}