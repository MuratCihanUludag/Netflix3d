using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Features.Mediator.Commands.AppUserCommand
{
    public class CreateAppUserCommandValidator : AbstractValidator<CreateAppUserCommand>
    {
        public CreateAppUserCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Min 6").Matches(@"[A-Z]+").WithMessage("1 Upper Case");
        }
    }
}
