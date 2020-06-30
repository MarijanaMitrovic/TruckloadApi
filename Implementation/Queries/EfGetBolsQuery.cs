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
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetBolsQuery : IGetBolsQuery
    {
        private readonly TruckloadContext context;
        private readonly IMapper mapper;


        public EfGetBolsQuery(TruckloadContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public int Id => 24;
        public string Name => "Search bill of ladings";

        public PagedResponse<BolDto> Execute(BolSearch search)
        {
            var query = context.BillOfLadings
                .Include(x => x.Load)
                .Include(x => x.Driver)
                .AsQueryable();

            if (!(search.LoadId == 0))
            {
                query = query.Where(x => x.LoadId == search.LoadId);
            }
            if (!(search.DriverId == 0))
            {
                query = query.Where(x => x.DriverId == search.DriverId);
            }

            return query.Paged<BillOfLading, BolDto >(search, mapper);
        }
    }
}
