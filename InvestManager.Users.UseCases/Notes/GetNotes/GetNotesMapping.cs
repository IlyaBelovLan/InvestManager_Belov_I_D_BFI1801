namespace InvestManager.Users.UseCases.Notes.GetNotes
{
    using System.Globalization;
    using AutoMapper;
    using Database.Models;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class GetNotesMapping : Profile
    {
        public GetNotesMapping()
        {
            CreateMap<EntityNote, Note>()
                .ForMember(d => d.CreateDate, o => o.MapFrom(s => s.CreateDate.ToString(CultureInfo.InvariantCulture)));
        }
    }
}