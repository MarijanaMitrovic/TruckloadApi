using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class ModelProfiles : Profile

    {
        public ModelProfiles()
        {
            CreateMap<Model, ModelDto>();
            CreateMap<CreateModelDto, Model>();
        }
    }
}
