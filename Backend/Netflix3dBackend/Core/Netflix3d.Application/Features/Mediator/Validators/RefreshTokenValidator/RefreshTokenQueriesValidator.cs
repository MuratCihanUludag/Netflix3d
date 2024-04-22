using FluentValidation;
using Netflix3d.Application.Features.Mediator.Queries.RefreshTokenQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Features.Mediator.Validators.RefreshTokenValidator
{
    public class RefreshTokenQueriesValidator : AbstractValidator<RefreshTokenQueries>
    {
        public RefreshTokenQueriesValidator()
        {
            RuleFor(x => x.AccessToken)
                .NotEmpty()
                .WithMessage("AccessToken connot be empty");

            RuleFor(x => x.RefreshToken)
                .NotEmpty()
                .WithMessage("RefreshToken connot be empty");
        }
    }
}
