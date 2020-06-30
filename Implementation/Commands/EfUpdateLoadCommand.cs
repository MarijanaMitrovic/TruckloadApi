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
    public class EfUpdateLoadCommand : IUpdateLoadCommand
    {

        private readonly TruckloadContext context;
        private readonly UpdateLoadValidator validator;
        private readonly IMapper mapper;

        public EfUpdateLoadCommand(TruckloadContext context, UpdateLoadValidator validator, IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public int Id => 22;
        public string Name => "Update load";

        public void Execute(CreateLoadDto request)
        {
            validator.ValidateAndThrow(request);
            var load = context.Loads.Find(request.Id);


            // truck.RegistrationMark = request.RegistrationMark;
            //truck.Label = request.Label;
            //truck.ModelId = request.ModelId;

            mapper.Map(request, load);

            context.SaveChanges();
        }
    }
}
