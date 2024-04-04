using MediatR;
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
    public class CreatAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatAppUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {

            var userRole = await _unitOfWork.GetReadRepository<AppRole>().GetSingleAsync(u => u.RoleName == "User");

            var appUser = _mapper.Map<AppUser, CreateAppUserCommand>(request);

            appUser.AppRoleId = userRole.Id;

            await _unitOfWork.GetWriteRepository<AppUser>().AddAsync(appUser);

        }
    }
}
