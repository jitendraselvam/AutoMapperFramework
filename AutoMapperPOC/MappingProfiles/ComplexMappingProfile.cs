using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Entities.ViewModels;

namespace AutoMapperPOC.MappingProfiles
{
    public class ComplexMappingProfile : Profile
    {
        public ComplexMappingProfile()
        {
            CreateMap<ComplexPersonIncomingDto, ComplexPerson>()
                .ForMember(dest => dest.Address,
                    opts => opts.MapFrom(
                        src => new Address
                        {
                            HouseNumber = src.HouseNumber,
                            Street = src.Street,
                            City = src.City,
                            State = src.State,
                            ZipCode = src.ZipCode
                        }));

            CreateMap<ComplexPerson, ComplexPersonDto>()
                .ForMember(dest => dest.City,
                    opts => opts.MapFrom(
                        src => src.Address.City
                    )).ReverseMap();
        }
    }
}
