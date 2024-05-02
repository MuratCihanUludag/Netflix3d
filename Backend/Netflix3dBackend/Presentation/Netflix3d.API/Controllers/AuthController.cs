using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix3d.Application.Features.Mediator.Commands.AppUserCommand;
using Netflix3d.Application.Features.Mediator.Queries.AppUserQueries;
using Netflix3d.Application.Features.Mediator.Queries.RefreshTokenQueries;

namespace Netflix3d.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            var response = await _mediator.Send(query);
            return StatusCode(StatusCodes.Status200OK, response);
        }
        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenQueries queries)
        {
            var response = await _mediator.Send(queries);
            return StatusCode(StatusCodes.Status200OK, response);
        }
        [HttpPost]
        public async Task<IActionResult> Revoke (RevokeCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
