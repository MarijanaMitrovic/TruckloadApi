using Application.Commands;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfUpdateTruckCommand : IUpdateTruckCommand
    {

        private readonly TruckloadContext context;
        private readonly UpdateTruckValidator validator;
        private readonly IMapper mapper;

        public EfUpdateTruckCommand(TruckloadContext context, UpdateTruckValidator validator, IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public int Id => 19;
        public string Name => "Update truck";

        public void Execute(CreateTruckDto request)
        {
            validator.ValidateAndThrow(request);
            var truck = context.Trucks.Find(request.Id);


            truck.RegistrationMark = request.RegistrationMark;
            truck.Label = request.Label;
            truck.ModelId = request.ModelId;

          //  mapper.Map(request, truck);

            context.SaveChanges();
        }
    }
}
