using Appointments.Core;
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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService doctorService;
        private readonly IMapper mapper;
        public DoctorController(IDoctorService _doctorService, IMapper _mapper)
        {
            doctorService = _doctorService;
            mapper = _mapper;
        }


        // GET: api/<DoctorController>
        [HttpGet]
        public IEnumerable<DoctorDTO> Get()
        {
            return mapper.Map<IEnumerable<DoctorDTO>>(doctorService.GetAll());
        }

        // GET api/<DoctorController>/5
        [HttpGet("id/{id}")]
        public DoctorDTO GetById(string id)
        {
            return mapper.Map<DoctorDTO>(doctorService.GetById(id));
        }

        // GET: api/<DoctorController/male>
        [HttpGet("gender/{gender}")]
        public IEnumerable<DoctorDTO> GetByGender(Gender gender)
        {
            return mapper.Map<IEnumerable<DoctorDTO>>(doctorService.GetByGender(gender));
        }


        // GET: api/<DoctorController/english>
        [HttpGet("language/{language}")]
        public IEnumerable<DoctorDTO> GetByLanguage(string language)
        {
            return mapper.Map<IEnumerable<DoctorDTO>>(doctorService.GetByLanguage(language));
        }

        // GET api/<DoctorController>/levi
        [HttpGet("name/{name}")]
        public DoctorDTO GetByName(string name)
        {
            return mapper.Map<DoctorDTO>(doctorService.GetByName(name));
        }

        // GET: api/<DoctorController/doctor>
        [HttpGet("specialty/{specialty}")]
        public IEnumerable<DoctorDTO> GetBySpecialty(int specialty)
        {
            return mapper.Map<IEnumerable<DoctorDTO>>(doctorService.GetBySpecialty(specialty));
        }


        // POST api/<DoctorController>
        [Authorize]
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Doctor doctor)
        {
            if (doctorService.AddDoctor(doctor))
                return Ok(doctor);
            return BadRequest("doctor exists already or speacialty is wrong");
        }

        // PUT api/<DoctorController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] Doctor doctor)
        {
            await doctorService.UpdateDoctor(doctor, id);
        }

        // DELETE api/<DoctorController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await doctorService.DeleteDoctor(id);
        }
    }
}
