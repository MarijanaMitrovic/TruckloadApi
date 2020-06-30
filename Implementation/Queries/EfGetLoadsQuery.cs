using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using Bogus;
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
    public class EfGetLoadsQuery : IGetLoadsQuery
    {

        private readonly TruckloadContext context;
        private readonly IMapper mapper;
        

        public EfGetLoadsQuery(TruckloadContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 1;

        public string Name => "Loads search";

        public PagedResponse<LoadDto> Execute(LoadSearch search)
        {
           


            var query = context.Loads
                .Include(x=>x.DriverLoads)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.From) || !string.IsNullOrWhiteSpace(search.From))
            {
                query = query.Where(x => x.From.ToLower().Contains(search.From.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.To) || !string.IsNullOrWhiteSpace(search.To))
            {
                query = query.Where(x => x.To.ToLower().Contains(search.To.ToLower()));
            }

            return query.Paged<Load, LoadDto>(search, mapper);
            


        }




    }
}
