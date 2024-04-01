using MediatR;
using Netflix3d.Application.Features.Mediator.Commands.AppUserCommand.cs;
using Netflix3d.Application.Repositories;
using Netflix3d.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreatAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IWriteRepositry<AppUser> _writeAppUserRepositry;
        private readonly IReadRepository<AppRole> _readAppRoleRepositry;

        public CreatAppUserCommandHandler(IWriteRepositry<AppUser> writeAppUserRepositry, IReadRepository<AppRole> readAppRoleRepositry)
        {
            _writeAppUserRepositry = writeAppUserRepositry;
            _readAppRoleRepositry = readAppRoleRepositry;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var userRole = await _readAppRoleRepositry.GetSingleAsync(u => u.RoleName == "User");

            _ = await _writeAppUserRepositry.AddAsync(new AppUser
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Password = request.Password,
                AppRoleId = userRole.Id
            }); ;
        }
    }
}
