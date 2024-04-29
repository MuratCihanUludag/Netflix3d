using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Netflix3d.Application.Abstractions;
using Netflix3d.Application.Abstractions.AutoMapper;
using Netflix3d.Application.Features.Mediator.Commands.AppUserCommand;
using Netflix3d.Application.Repositories;
using Netflix3d.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        public RegisterCommandHandler(UserManager<AppUser> userManager, IMapper mapper, IMailService mailService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mailService = mailService;

        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            var appUser = _mapper.Map<AppUser, RegisterCommand>(request);

            appUser.UserName = request.Email;

            appUser.SecurityStamp = Guid.NewGuid().ToString();

            await _userManager.CreateAsync(appUser, request.Password);

            await _userManager.AddToRoleAsync(appUser, "User");

            await _mailService.EmailVerifier(appUser);

            return Unit.Value;
        }
    }
}
