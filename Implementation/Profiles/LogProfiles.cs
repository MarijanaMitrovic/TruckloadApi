using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class LogProfiles : Profile
    {

        public LogProfiles(){

            CreateMap<UseCaseLog, LogsDto>();

       }

    }
}
