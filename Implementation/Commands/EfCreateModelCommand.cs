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
    public class EfCreateModelCommand : ICreateModelCommand
    {

        private readonly TruckloadContext context;
        private readonly InsertModelValidator validator;


        public EfCreateModelCommand(TruckloadContext context, InsertModelValidator validator)
        {
            this.context = context;
            this.validator = validator;

        }


        public int Id => 17;

        public string Name => "Create new model";

        public void Execute(CreateModelDto request)
        {
            validator.ValidateAndThrow(request);

            var model = new Model
            {
                Name = request.Name,
                YearOfProduction= request.YearOfProduction,
                Color = request.Color
            };

            context.Models.Add(model);

            context.SaveChanges();
        }
    }
}
