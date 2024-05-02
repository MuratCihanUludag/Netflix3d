using FluentValidation;
using Netflix3d.Application.Features.Mediator.Commands.AppUserCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Features.Mediator.Validators.AppUserValidator
{
    public class RevokeCommandValidator : AbstractValidator<RevokeCommand>
    {
        public RevokeCommandValidator()
        {
            RuleFor(user => user.Email)
                .EmailAddress()
                .NotEmpty();
        }

    }
}
