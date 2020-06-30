using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
   public class InsertTruckValidator : AbstractValidator<CreateTruckDto>
    {
        public InsertTruckValidator(TruckloadContext context)
        {
            RuleFor(x => x.RegistrationMark)
                .NotEmpty()
                .Must(rm => !context.Trucks.Any(t => t.RegistrationMark == rm))
                .WithMessage("Registration mark must be unique");

            RuleFor(x => x.Label)
                .NotEmpty()
                .Must(l => !context.Trucks.Any(t => t.Label == l))
                .WithMessage("Label must be unique");

            RuleFor(x => x.ModelId)
                .NotEmpty()
                .Must(m => context.Models.Any(t => t.Id == m))
                .WithMessage("This model Id does not exist");
        }

    }
}
