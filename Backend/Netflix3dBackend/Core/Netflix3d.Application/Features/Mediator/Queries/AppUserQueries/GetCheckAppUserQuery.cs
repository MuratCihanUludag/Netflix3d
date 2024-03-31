using MediatR;
using Netflix3d.Application.Features.Mediator.Results.AppUserResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Features.Mediator.Queries.AppUserQueries
{
    public class GetCheckAppUserQuery : IRequest<GetCheckAppUserQueryResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
