namespace InvestManager.WebApi.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Users.UseCases.Notes.CreateNote;
    using Users.UseCases.Notes.GetNotes;

    [ApiController]
    [Route("[controller]/[action]")]
    public class NotesController : Controller
    {
        private readonly IMediator _mediator;

        public NotesController(IMediator mediator) => _mediator = mediator;
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateNote(CreateNoteCommand command)
        {
            await _mediator.Send(command).ConfigureAwait(false);
            return Ok();
        }
        
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(GetNotesResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNotes(GetNotesQuery query)
        {
            var response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }
    }
}