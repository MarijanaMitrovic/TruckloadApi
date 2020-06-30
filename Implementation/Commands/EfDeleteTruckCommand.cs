using Application.Commands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfDeleteTruckCommand : IDeleteTruckCommand
    {

        private readonly TruckloadContext context;

        public EfDeleteTruckCommand(TruckloadContext context)
        {
            this.context = context;
        }

        public int Id => 11;

        public string Name => "Delete truck";

        public void Execute(int request)
        {
            var truck = context.Trucks.Find(request);

            if (truck == null)
            {
                throw new EntityNotFoundException(request, typeof(Truck));
            }

            context.Trucks.Remove(truck);

            context.SaveChanges();
        }
    }
}
