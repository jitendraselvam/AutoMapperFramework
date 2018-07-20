using AutoMapper;
using Entities;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AutoMapperPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplexMappingController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ComplexMappingController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Maps a ComplexPerson object to ComplexPersonViewModel Object
        /// </summary>
        /// <response code="200">Returns a ComplexPersonViewModel Object mapped from ComplexPerson Object</response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ComplexPersonDto), 200)]
        public ActionResult<ComplexPersonDto> Get()
        {
            return _mapper.Map<ComplexPersonDto>(SampleComplexPerson);
        }


        /// <summary>
        /// Gets a ComplexPersonIncomingDTO object and maps to ComplexPerson Object
        /// </summary>
        /// <response code="200">Returns a ComplexPerson Object mapped from ComplexPersonIncomingDTO Object</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ComplexPerson), 200)]
        public ActionResult<ComplexPerson> PostPerson([FromBody] ComplexPersonIncomingDto newComplexPerson)
        {
            return _mapper.Map<ComplexPerson>(newComplexPerson);
        }


        /// <summary>
        /// update a ComplexPerson Object
        /// </summary>
        /// <response code="200">Returns a ComplexPerson Object with the updated details mapped to ComplexPersonViewModel object</response>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ComplexPerson> UpdateComplexPersonCity([FromBody] ComplexPersonDto newComplexPerson)
        {
            return _mapper.Map(newComplexPerson, SampleComplexPerson);
        }

        /// <summary>
        /// Method to create a Sample Complex Person
        /// </summary>
        /// <returns></returns>
        private ComplexPerson SampleComplexPerson =>
            new ComplexPerson
            {
                Age = 23,
                Firstname = "John",
                Lastname = "Doe",
                Sex = "M",
                Address = new Address()
                {
                    City = "Bloomington",
                    HouseNumber = "123",
                    State = "Indiana",
                    Street = "IU Street",
                    ZipCode = "47404"
                }
            };

    }
}