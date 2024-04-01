using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Netflix3d.Application.Features.Mediator.Queries.AppUserQueries;
using Netflix3d.Application.Tools;

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
        public async Task<IActionResult> Index(GetCheckAppUserQuery query)
        {
            var values = await _mediator.Send(query);
            if (values.IsExist)
            {
                return Created("", JwtTokenGenerator.TokenGenerator(values));
            }
            else
            {
                return BadRequest("Kullanici adiniz veya sifreniz hatalidir.");
            }

        }
    }
}
