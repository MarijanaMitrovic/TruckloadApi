using Application.Commands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
   public class EfDeleteLoadCommand : IDeleteLoadCommand
    {
        private readonly TruckloadContext context;

        public EfDeleteLoadCommand(TruckloadContext context)
        {
            this.context = context;
        }

        public int Id => 10;

        public string Name => "Delete load";

        public void Execute(int request)
        {
            var load = context.Loads.Find(request);

            if (load == null)
            {
                throw new EntityNotFoundException(request, typeof(Load));
            }

            context.Loads.Remove(load);

            context.SaveChanges();
        }
    }
}
