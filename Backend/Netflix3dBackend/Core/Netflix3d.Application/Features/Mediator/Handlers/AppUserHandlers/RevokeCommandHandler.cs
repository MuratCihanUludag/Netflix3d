using MediatR;
using Microsoft.AspNetCore.Identity;
using Netflix3d.Application.Features.Mediator.Commands.AppUserCommand;
using Netflix3d.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class RevokeCommandHandler : IRequestHandler<RevokeCommand, Unit>
    {
        private readonly UserManager<AppUser> _userManager;
        public RevokeCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Unit> Handle(RevokeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                throw new Exception("Kullanici bulunamadi");
            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
