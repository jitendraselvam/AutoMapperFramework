using AutoMapper;
using Entities.ViewModels;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AutoMapperPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleMappingController : ControllerBase
    {
        private readonly IMapper _mapper;
        public SimpleMappingController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Returns a Person View Model Object mapped from Person Object
        /// </summary>
        /// <response code="200">Person object is mapped to Person View Model</response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PersonDto), 200)]
        public ActionResult<PersonDto> Get()
        {
            return _mapper.Map<PersonDto>(SamplePerson);
        }


        /// <summary>
        /// Gets a Person View Model object and maps to Person Object
        /// </summary>
        /// <response code="200">Returns a Person Object mapped from Person View Model Object</response>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Person), 200)]
        public ActionResult<Person> UpdatePerson([FromBody] PersonDto newPerson)
        {
            // Map from Source(newPerson) to Destination(SamplePerson)  leaving all other fields in destination intact
            return _mapper.Map(newPerson, SamplePerson);
        }


        private static Person SamplePerson => new Person
        {
            Age = 23,
            Department = "ABC",
            Firstname = "John",
            Lastname = "Doe",
            Id = 1,
            Profession = "Manager",
            Sex = "M"
        };
    }
}