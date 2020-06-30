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
    public class EfGetSingleLoad : IGetSingleLoad
    {

        private readonly TruckloadContext context;
        private readonly IMapper mapper;

        public EfGetSingleLoad(TruckloadContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 6;
        public string Name => "Get single load";

        public LoadDto Execute(int search)
        {
            var query = context.Loads
                .Include(x => x.DriverLoads)
                .AsQueryable();

             var load = query.FirstOrDefault(x => x.Id == search);

            if (load == null)
            {
                throw new EntityNotFoundException(search, typeof(Load));
            }

            var response = mapper.Map<LoadDto>(load);
       
                
            return response;
        }

    }
}
