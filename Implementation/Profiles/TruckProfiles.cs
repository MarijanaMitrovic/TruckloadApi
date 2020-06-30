using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class TruckProfiles : Profile
    {
        public TruckProfiles() {

            CreateMap<Truck, TruckDto>()
                   .ForMember(dto => dto.Model, opt => opt.MapFrom(t => t.Model.Name))
                   .ForMember(dto => dto.Year, opt => opt.MapFrom(t => t.Model.YearOfProduction));

            CreateMap<CreateTruckDto, Truck>();
        }

       
        
    }
}
