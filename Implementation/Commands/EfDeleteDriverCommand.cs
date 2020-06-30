using Application.Commands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfDeleteDriverCommand : IDeleteDriverCommand
    {

        private readonly TruckloadContext context;

        public EfDeleteDriverCommand(TruckloadContext context)
        {
            this.context = context;
        }

        public int Id => 13;

        public string Name => "Delete driver";

        public void Execute(int request)
        {
            var driver = context.Drivers.Find(request);

            if (driver == null)
            {
                throw new EntityNotFoundException(request, typeof(Driver));
            }

            context.Drivers.Remove(driver);

            context.SaveChanges();
        }
    }
}
