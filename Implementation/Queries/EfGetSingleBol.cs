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
    public class EfGetSingleBol : IGetSingleBol
    {

        private readonly TruckloadContext context;
        private readonly IMapper mapper;

        public EfGetSingleBol(TruckloadContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 25;
        public string Name => "Get single bill of lading";

        public BolDto Execute(int search)
        {
            var query = context.BillOfLadings
               .Include(x => x.Load)
               .Include(x => x.Driver)
               .AsQueryable();

            var bol = query.FirstOrDefault(x => x.Id == search);

            if (bol == null)
            {
                throw new EntityNotFoundException(search, typeof(BillOfLading));
            }

            var response = mapper.Map<BolDto>(bol);


            return response;
        }
    }
}
