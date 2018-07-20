using AutoMapper;
using Entities;
using Entities.ViewModels;

namespace AutoMapperPOC.MappingProfiles
{
    public class SimpleMappingProfile : Profile
    {
        public SimpleMappingProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
        }

    }
}
