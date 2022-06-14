namespace InvestManager.Users.UseCases.Notes.GetNotes
{
    using System.Collections.Generic;
    using JetBrains.Annotations;

    [PublicAPI]
    public class GetNotesResponse
    {
        public IReadOnlyCollection<Note> Notes { get; set; }
        
        public int Count { get; set; }
    }
}