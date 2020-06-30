using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {

        public RegisterUserValidator(TruckloadContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty();

            RuleFor(x => x.LastName).NotEmpty();

            RuleFor(x => x.Email)
               .NotEmpty()
               .Must(x => !context.Users.Any(user => user.Email == x))
               .WithMessage("Email is already used")
               .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);                   

            RuleFor(x => x.Phone)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}
