using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Netflix3d.Application.Abstractions;
using Netflix3d.Application.Features.Mediator.Queries.AppUserQueries;

namespace Netflix3d.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginQuery query)
        {
            var response = await _mediator.Send(query);
            return StatusCode(StatusCodes.Status200OK,response);
        }
    }
}
