using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Profiles
{
   public class LoadProfiles : Profile
    {
        public LoadProfiles()
        {
            CreateMap<Load, LoadDto>()
                .ForMember(dto => dto.DriverLoads, opt => opt.MapFrom(load => load.DriverLoads.Select(dl => new DriverLoadDto
                {
                    Id = dl.Id,
                    Name = dl.Name,
                    LastName = dl.LastName
                })));

            CreateMap<CreateLoadDto, Load>()
               .ForMember(load => load.DriverLoads, opt => opt.MapFrom(dto => dto.Items.Select(dl => new DriverLoad
               {
                   Id = dl.DriverId,
                   Name = dl.Name,
                   LastName = dl.LastName
               })));
        }
    }
}
