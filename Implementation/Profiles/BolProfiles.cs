using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class BolProfiles : Profile
    {
        public BolProfiles()
        {
            CreateMap<BillOfLading, BolDto>()
                 .ForMember(dto => dto.Name, opt => opt.MapFrom(t => t.Driver.Name))
                  .ForMember(dto => dto.LastName, opt => opt.MapFrom(t => t.Driver.LastName))
                   .ForMember(dto => dto.From, opt => opt.MapFrom(t => t.Load.From))
                    .ForMember(dto => dto.To, opt => opt.MapFrom(t => t.Load.To));
        }
    }
}
