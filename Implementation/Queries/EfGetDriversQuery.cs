using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetDriversQuery : IGetDriversQuery
    {
        private readonly TruckloadContext context;
        private readonly IMapper mapper;


        public EfGetDriversQuery(TruckloadContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 4;
        public string Name => "Search drivers";

        public PagedResponse<DriverDto> Execute(DriverSearch search)
        {
            var query = context.Drivers
                .Include(x => x.Truck)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.LastName) || !string.IsNullOrWhiteSpace(search.LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
            }


            return query.Paged<Driver, DriverDto>(search, mapper);
        }

    }
}
