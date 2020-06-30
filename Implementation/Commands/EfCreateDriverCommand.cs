using Application.Commands;
using Application.DataTransfer;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfCreateDriverCommand : ICreateDriverCommand
    {

        private readonly TruckloadContext context;
        private readonly InsertDriverValidator validator;


        public EfCreateDriverCommand(TruckloadContext context, InsertDriverValidator validator)
        {
            this.context = context;
            this.validator = validator;

        }


        public int Id => 18;

        public string Name => "Create new driver";

        public void Execute(CreateDriverDto request)
        {
            validator.ValidateAndThrow(request);

            var driver = new Driver
            {
                Name = request.Name,
                LastName = request.LastName,
                TruckId = request.TruckId
            };

            context.Drivers.Add(driver);

            context.SaveChanges();
        }
    }
}
