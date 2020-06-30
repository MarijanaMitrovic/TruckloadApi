using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class DriverProfiles : Profile
    { 
       public DriverProfiles()
        {
            CreateMap<Driver, DriverDto>()
                  .ForMember(dto => dto.RegistrationMark, opt => opt.MapFrom(t => t.Truck.RegistrationMark))
                  .ForMember(dto => dto.Label, opt => opt.MapFrom(t => t.Truck.Label));

            CreateMap<CreateDriverDto, Driver>();
        }

        
      
    }
}
