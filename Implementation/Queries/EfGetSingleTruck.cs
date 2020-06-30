using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries;
using AutoMapper;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetSingleTruck : IGetSingleTruck
    {

        private readonly TruckloadContext context;
        private readonly IMapper mapper;

        public EfGetSingleTruck(TruckloadContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 7;
        public string Name => "Get single truck";

        public TruckDto Execute(int search)
        {
            var query = context.Trucks
                .Include(x => x.Model)
                .AsQueryable();

            var truck = query.FirstOrDefault(x => x.Id == search);

            if (truck == null)
            {
                throw new EntityNotFoundException(search, typeof(Truck));
            }



            var response = mapper.Map<TruckDto>(truck);


            return response;
        }
    }
}
