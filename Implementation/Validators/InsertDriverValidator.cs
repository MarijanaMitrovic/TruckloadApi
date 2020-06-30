using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class InsertDriverValidator : AbstractValidator<CreateDriverDto>
    {

        public InsertDriverValidator(TruckloadContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(40)
                .WithMessage("Name must contain less than 40 characters");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(40)
                .WithMessage("Last name must contain less than 40 characters");

            RuleFor(x => x.TruckId)
                .NotEmpty()
                .Must(m => context.Models.Any(t => t.Id == m))
                .WithMessage("This truck Id does not exist");
        }
    }
}
