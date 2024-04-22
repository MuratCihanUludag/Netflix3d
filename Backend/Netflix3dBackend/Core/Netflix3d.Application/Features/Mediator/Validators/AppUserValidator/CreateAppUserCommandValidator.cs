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
            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage("Name connot be empty");

            RuleFor(user => user.Surname)
                .NotEmpty()
                .WithMessage("Surname connot be empty");

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Email connot be empty.")
                .EmailAddress()
                .WithMessage("A valid email is required");
            RuleFor(user => user.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone Number connot be empty");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
                .Matches(@"^(.*[A-Z]){2,}.*$").WithMessage("Password must contain at least 2 uppercase letters.")
                .Matches(@"^(.*[a-z]){2,}.*$").WithMessage("Password must contain at lesat 2 lowercase letters.")
                .Must(pass => pass.Any(ch => !char.IsLetterOrDigit(ch))).WithMessage("Passowrd must contain at lesat 1 specila character");

        }
    }
}
