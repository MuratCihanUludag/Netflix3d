using MediatR;
using Microsoft.EntityFrameworkCore;
using Netflix3d.Application.Features.Mediator.Queries.AppUserQueries;
using Netflix3d.Application.Features.Mediator.Results.AppUserResults;
using Netflix3d.Application.Repositories;
using Netflix3d.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IReadRepository<AppUser> _appUserRepository;
        private readonly IReadRepository<AppRole> _appRoleRepository;

        public GetCheckAppUserQueryHandler(IReadRepository<AppUser> appUserRepository, IReadRepository<AppRole> appRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResult();

            var user = await _appUserRepository.GetSingleAsync(u => u.Email == request.Email && u.Password == request.Password, false);

            if (user == null)
            {
                values.IsExist = false;   
            }
            else
            {
                values.IsExist = true;
                values.Email = request.Email;
                values.Role = (await _appRoleRepository.GetSingleAsync(r => r.Id == user.AppRoleId, false)).RoleName;
                values.Id = user.Id;
            }
            return values;
        }
    }
}
