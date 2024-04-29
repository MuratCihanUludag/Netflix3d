using MediatR;
using Netflix3d.Application.Features.Mediator.Results.RefreshTokenResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Features.Mediator.Queries.RefreshTokenQueries
{
    public class RefreshTokenQueries : IRequest<RefreshTokenQueriesResult>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
