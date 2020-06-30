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
    public class EfGetLogsQuery : IGetLogsQuery
    {

        private readonly TruckloadContext context;
        private readonly IMapper mapper;


        public EfGetLogsQuery(TruckloadContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public int Id => 14;
        public string Name => "Search logs";

        public PagedResponse<LogsDto> Execute(LogSearch search)
        {
            var query = context.UseCaseLogs
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.Actor) || !string.IsNullOrWhiteSpace(search.Actor))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            if (!(search.DateFrom==null) || !(search.DateTo==null))
            {
                query = query.Where(x => x.Date>=search.DateFrom&&x.Date<=search.DateTo);
            }

            return query.Paged<UseCaseLog, LogsDto>(search, mapper);
        }
    }
}
