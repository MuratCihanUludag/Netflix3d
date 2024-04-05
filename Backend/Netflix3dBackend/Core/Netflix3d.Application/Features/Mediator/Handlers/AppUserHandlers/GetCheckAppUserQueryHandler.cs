using MediatR;
using Microsoft.EntityFrameworkCore;
using Netflix3d.Application.Abstractions;
using Netflix3d.Application.Abstractions.AutoMapper;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetCheckAppUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {

            var user = await _unitOfWork.GetReadRepository<AppUser>().GetSingleAsync(u => u.Email == request.Email && u.Password == request.Password, false);

            if (user == null)
                //throw new Exception("Kullanici bulunamadi
                throw new Exception("Kullanici bulunamadi");
            else
            {
                GetCheckAppUserQueryResult userResponse = new();
                userResponse = _mapper.Map<GetCheckAppUserQueryResult, AppUser>(user);
                userResponse.Role = (await _unitOfWork.GetReadRepository<AppRole>().GetSingleAsync(r => r.Id == user.AppRoleId, false)).RoleName;
                return userResponse;
            }
        }
    }
}
