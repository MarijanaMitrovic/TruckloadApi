using Application;
using Application.Commands;
using Application.DataTransfer;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfCreateTruckCommand : ICreateTruckCommand
    {

        private readonly TruckloadContext context;
        private readonly InsertTruckValidator validator;
       

        public EfCreateTruckCommand(TruckloadContext context, InsertTruckValidator validator)
        {
            this.context = context;
            this.validator = validator;
           
        }


        public int Id => 15;

        public string Name => "Create new truck";

        public void Execute(CreateTruckDto request)
        {
            validator.ValidateAndThrow(request); 

            var truck = new Truck
            {
                RegistrationMark = request.RegistrationMark,
                Label=request.Label,
                ModelId=request.ModelId
            };

            context.Trucks.Add(truck);

            context.SaveChanges();
        }
    }
}
