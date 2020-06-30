using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetSingleModel : IGetSingleModel
    {

        private readonly TruckloadContext context;
        private readonly IMapper mapper;

        public EfGetSingleModel(TruckloadContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 9;
        public string Name => "Get single model";

        public ModelDto Execute(int search)
        {
            var query = context.Models
                .AsQueryable();

            var model = query.FirstOrDefault(x => x.Id == search);

            if (model == null)
            {
                throw new EntityNotFoundException(search, typeof(Model));
            }

            var response = mapper.Map<ModelDto>(model);


            return response;
        }
    }
}
