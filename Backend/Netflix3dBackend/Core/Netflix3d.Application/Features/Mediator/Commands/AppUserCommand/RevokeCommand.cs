using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Features.Mediator.Commands.AppUserCommand
{
    public class RevokeCommand : IRequest<Unit>
    {
        public string Email { get; set; }
    }
}
