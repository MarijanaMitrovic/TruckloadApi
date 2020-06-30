using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq;

namespace Implementation.Validators
{
    public class UpdateLoadValidator : AbstractValidator<CreateLoadDto>
    {
        private readonly TruckloadContext context;
        public UpdateLoadValidator(TruckloadContext context)
        {
            RuleFor(x => x.From)
                    .NotEmpty()
                    .WithMessage("Pick up location is required");

            RuleFor(x => x.To)
                   .NotEmpty()
                   .WithMessage("Delivery location is required");



            RuleFor(x => x.PickUp)
                    .NotEmpty()
                    .GreaterThan(DateTime.Now)
                    .WithMessage("Time must be in future.")
                    .LessThan(DateTime.Now.AddDays(7))
                    .WithMessage("Pick up time can not be more than 7 days from now.");

            RuleFor(x => x.Delivery)
                   .NotEmpty()
                   .GreaterThan(DateTime.Now)
                   .WithMessage("Time must be in future.")
                   .LessThan(DateTime.Now.AddDays(7))
                   .WithMessage("Delivery time can not be more than 7 days from now.");

            RuleFor(x => x.Weight)
                .NotEmpty()
                .LessThan(42)
                .WithMessage("Weight of load can not be more than 42k.");

            RuleFor(x => x.Miles)
                .NotEmpty()
                .GreaterThan(100)
                .WithMessage("Mileage must be more than 100.");

            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThan(100)
                .WithMessage("Price can not be less than 100.");

            RuleFor(x => x.Items)
               .NotEmpty()
               .WithMessage("There must be at least one driver.")
               .Must(i => i.Select(x => x.DriverId).Distinct().Count() == i.Count())
               .WithMessage("Duplicate drivers are not allowed.")
               .DependentRules(() =>
               {
                   RuleForEach(x => x.Items).SetValidator
                       (new InsertDriverLoadValidator(context));
               });


        }
    }
}
