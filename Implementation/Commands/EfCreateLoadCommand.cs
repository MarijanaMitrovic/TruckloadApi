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
   public class EfCreateLoadCommand : ICreateLoadCommand
    {

        private readonly TruckloadContext context;
        private readonly InsertLoadValidator validator;


        public EfCreateLoadCommand(TruckloadContext context, InsertLoadValidator validator)
        {
            this.context = context;
            this.validator = validator;

        }


        public int Id => 16;

        public string Name => "Create new load";


        public void Execute(CreateLoadDto request)
        {
            validator.ValidateAndThrow(request);

            var load = new Load
            {
                From = request.From,
                To = request.To,
                PickUp = request.PickUp,
                Delivery=request.Delivery,
                Weight=request.Weight,
                Miles=request.Miles,
                Price=request.Price
            };
            foreach (var item in request.Items)
            {
                var driver = context.Drivers.Find(item.DriverId);

                load.DriverLoads.Add(new DriverLoad
                {
                    DriverId = item.DriverId,
                    Name = item.Name,
                    LastName = item.LastName
                });
            }

            context.Loads.Add(load);

            context.SaveChanges();
        }
    }
}
