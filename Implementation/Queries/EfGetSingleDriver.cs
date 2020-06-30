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
    public class EfGetSingleDriver : IGetSingleDriver
    {

        private readonly TruckloadContext context;
        private readonly IMapper mapper;

        public EfGetSingleDriver(TruckloadContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 8;
        public string Name => "Get single driver";

        public DriverDto Execute(int search)
        {
            var query = context.Drivers
                .Include(x => x.Truck)
                .AsQueryable();

            var driver = query.FirstOrDefault(x => x.Id == search);

            if (driver == null)
            {
                throw new EntityNotFoundException(search, typeof(Driver));
            }

            var response = mapper.Map<DriverDto>(driver);


            return response;
        }
    }
}
