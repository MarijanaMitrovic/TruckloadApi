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
    public class EfUpdateDriverCommand :IUpdateDriverCommand
    {

        private readonly TruckloadContext context;
        private readonly UpdateDriverValidator validator;
        private readonly IMapper mapper;

        public EfUpdateDriverCommand(TruckloadContext context, UpdateDriverValidator validator, IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public int Id => 21;
        public string Name => "Update driver";

        public void Execute(CreateDriverDto request)
        {
            validator.ValidateAndThrow(request);
            var driver = context.Drivers.Find(request.Id);


            // truck.RegistrationMark = request.RegistrationMark;
            //truck.Label = request.Label;
            //truck.ModelId = request.ModelId;

            mapper.Map(request, driver);

            context.SaveChanges();
        }
    }
}
