using Application.Commands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
   public class EfDeleteModelCommand : IDeleteModelCommand
    {

        private readonly TruckloadContext context;

        public EfDeleteModelCommand(TruckloadContext context)
        {
            this.context = context;
        }

        public int Id => 12;

        public string Name => "Delete model";

        public void Execute(int request)
        {
            var model = context.Models.Find(request);

            if (model == null)
            {
                throw new EntityNotFoundException(request, typeof(Model));
            }

            context.Models.Remove(model);

            context.SaveChanges();
        }
    }
}
