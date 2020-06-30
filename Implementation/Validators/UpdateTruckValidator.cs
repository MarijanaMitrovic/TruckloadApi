using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class UpdateTruckValidator : AbstractValidator<CreateTruckDto>
    {

        public UpdateTruckValidator(TruckloadContext context)
        {
            RuleFor(x => x.RegistrationMark)
                .NotEmpty()
                .Must((dto, rm) => !context.Trucks.Any(t => t.RegistrationMark == rm && t.Id != dto.Id))
                .WithMessage("Registration mark must be unique");

            RuleFor(x => x.Label)
                .NotEmpty()
                .Must((dto, rm) => !context.Trucks.Any(t => t.Label == rm && t.Id != dto.Id))
                .WithMessage("Label must be unique");

            RuleFor(x => x.ModelId)
                .NotEmpty()
                .Must(m => context.Models.Any(t => t.Id == m))
                .WithMessage("This model Id does not exist");
        }
    }
}
