﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix3d.Application.Features.Mediator.Commands.AppUserCommand.cs;

namespace Netflix3d.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateAppUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Basarili");
        }
    }
}