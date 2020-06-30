using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validators
{
   public class UpdateModelValidator : AbstractValidator<CreateModelDto>
    {
        public UpdateModelValidator(TruckloadContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name field can not be empty.");

            RuleFor(x => x.YearOfProduction)
                .NotEmpty()
                .WithMessage("Year field can not be empty.");

            RuleFor(x => x.Color)
                .NotEmpty()
                .WithMessage("Color field can not be empty.");
        }
    }
}
