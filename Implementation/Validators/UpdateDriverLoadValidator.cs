using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class UpdateDriverLoadValidator : AbstractValidator<CreateDriverLoadDto>
    {
        private readonly TruckloadContext context;
        public UpdateDriverLoadValidator(TruckloadContext context)
        {

            this.context = context;

            RuleFor(x => x.DriverId)
            .Must(DriverExists)
            .WithMessage("Driver with an id of {PropertyValue} doesn't exist.")
            .DependentRules(() =>
            {
                RuleFor(x => x.Name)
                .Must(NameIsSameLikeInDriversTable)
                .WithMessage("That name does not belong to user with choosen Id");

                RuleFor(x => x.LastName)
               .Must(LastNameIsSameLikeInDriversTable)
               .WithMessage("That last name does not belong to user with choosen Id");
            });


        }


        private bool DriverExists( int driverId)
        {
            return context.Drivers.Any(x => x.Id == driverId);
        }

        private bool NameIsSameLikeInDriversTable(CreateDriverLoadDto dto, string name)
        {
            return context.Drivers.Find(dto.Name).Name == name;
        }

        private bool LastNameIsSameLikeInDriversTable(CreateDriverLoadDto dto, string lastName)
        {
            return context.Drivers.Find(dto.LastName).LastName == lastName;
        }

    }
}
