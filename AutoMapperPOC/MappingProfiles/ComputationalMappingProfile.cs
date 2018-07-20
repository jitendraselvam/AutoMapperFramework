using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Entities.ViewModels;

namespace AutoMapperPOC.MappingProfiles
{
    public class ComputationalMappingProfile : Profile
    {
        public ComputationalMappingProfile()
        {
            CreateMap<ShoppingBag, ShoppingBagDto>();
        }
    }
}
