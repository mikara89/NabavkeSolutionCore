using AutoMapper;
using NabavkeSolutionCore.Data.Models.Code_First_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NabavkeSolutionCore.Controllers.Resourses;

namespace NabavkeSolutionCore.Mapping 
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Nabavka, NabavaShortDto>();
            CreateMap<Nabavka, NabavkaMediumDto>();
            CreateMap<Mesto, MestoDto>();
        }
    }
}
