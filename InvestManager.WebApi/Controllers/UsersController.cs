namespace InvestManager.WebApi.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Users.UseCases.Users.LogIn;
    using Users.UseCases.Users.RegisterUser;

    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator) => _mediator = mediator;
        
        [HttpPost]
        [ProducesResponseType(typeof(RegisterUserResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand command)
        {
            var response = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(response);
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(LogInResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> LogIn(LogInQuery query)
        {
            var response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }
    }
}