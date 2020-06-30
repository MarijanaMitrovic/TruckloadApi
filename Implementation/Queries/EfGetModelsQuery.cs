using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetModelsQuery : IGetModelsQuery
    {

        private readonly TruckloadContext context;
        private readonly IMapper mapper;


        public EfGetModelsQuery(TruckloadContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public int Id => 5;
        public string Name => "Search models";

        public PagedResponse<ModelDto> Execute(ModelSearch search)
        {
            var query = context.Models
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (!(search.Year == 0))
            {
                query = query.Where(x => x.YearOfProduction == search.Year);
            }

            return query.Paged<Model, ModelDto>(search, mapper);
        }
    }
}
