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
    public class EfUpdateModelCommand : IUpdateModelCommand
    {

        private readonly TruckloadContext context;
        private readonly UpdateModelValidator validator;
        private readonly IMapper mapper;

        public EfUpdateModelCommand(TruckloadContext context, UpdateModelValidator validator, IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public int Id => 20;
        public string Name => "Update model";

        public void Execute(CreateModelDto request)
        {
            validator.ValidateAndThrow(request);
            var model = context.Models.Find(request.Id);


            // truck.RegistrationMark = request.RegistrationMark;
            //truck.Label = request.Label;
            //truck.ModelId = request.ModelId;

            mapper.Map(request, model);

            context.SaveChanges();
        }
    }
}
