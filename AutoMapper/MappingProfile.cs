using AutoMapper;
using SEMA.Dto;
using SEMA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEMA.AutoMapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Events, EventDto>().ReverseMap();
        }
    }
}
