using Appointments.Core.DTO;
using Appointments.Core.Entities;
using Appointments.Core.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Appointments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private readonly ISpecialtyService specialtyService;
        private readonly IMapper mapper;

        public SpecialtyController(ISpecialtyService _specialtyService, IMapper _mapper)
        {
            specialtyService = _specialtyService;
            mapper = _mapper;
        }


        // GET: api/<SpecialtyController>
        [HttpGet]
        public IEnumerable<SpecialtyDTO> Get()
        {
            return mapper.Map<IEnumerable<SpecialtyDTO>>(specialtyService.GetAll());
        }

        // GET api/<SpecialtyController>/5
        [HttpGet("id/{id}")]
        public SpecialtyDTO GetById(int id)
        {
            return mapper.Map<SpecialtyDTO>(specialtyService.GetById(id));
        }

        // GET api/<SpecialtyController>/doctor
        [HttpGet("name/{name}")]
        public SpecialtyDTO GetByName(string name)
        {
            return mapper.Map<SpecialtyDTO>(specialtyService.GetByName(name));
        }

        // POST api/<SpecialtyController>
        [Authorize]
        [HttpPost]
        public async Task Post([FromBody] Specialty specialty)
        {
            await specialtyService.AddSpecialty(specialty);

        }

        // PUT api/<SpecialtyController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Specialty specialty)
        {
            await specialtyService.UpdateSpecialty(id, specialty);
        }

        // DELETE api/<SpecialtyController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await specialtyService.DeleteSpecialty(id);
        }
    }
}
