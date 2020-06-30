using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using Bogus.DataSets;
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
    public class EfGetTrucksQuery : IGetTrucksQuery
    {

        private readonly TruckloadContext context;
        private readonly IMapper mapper;


        public EfGetTrucksQuery(TruckloadContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public int Id => 3;
        public string Name => "Search trucks";

        public PagedResponse<TruckDto> Execute(TruckSearch search)
        {
            var query = context.Trucks
                .Include(x => x.Model)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.RegistrationMark) || !string.IsNullOrWhiteSpace(search.RegistrationMark))
            {
                query = query.Where(x => x.RegistrationMark.ToLower().Contains(search.RegistrationMark.ToLower()));
            }

            if (!(search.Label==0))
            {
                query = query.Where(x => x.Label==search.Label);
            }

            return query.Paged<Truck, TruckDto>(search, mapper);
        }
    }
}
