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
    public class PatientController : ControllerBase
    {
        private readonly IPatientService patientService;
        private readonly IMapper mapper;
        public PatientController(IPatientService _patientService, IMapper _mapper)
        {
            patientService = _patientService;
            mapper = _mapper;
        }


        // GET: api/<PatientController>
        [Authorize]
        [HttpGet]
        public IEnumerable<PatientDTO> Get()
        {
            return mapper.Map<IEnumerable<PatientDTO>>(patientService.GetAll());
        }

        // GET api/<PatientController>/5
        [HttpGet("id/{id}")]
        public PatientDTO GetById(string id)
        {
            return mapper.Map<PatientDTO>(patientService.GetById(id));
        }


        // GET api/<PatientController>/5
        [HttpGet("id/{id}/passeord/{password}")]
        public PatientDTO GetByPassword(string id, string password)
        {
            return mapper.Map<PatientDTO>(patientService.GetByPassword(id, password));
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine(ModelState);
                return BadRequest(ModelState);
            }
            await patientService.AddPatient(patient);
            return Ok();
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] Patient patient)
        {
            await patientService.UpdatePatient(patient, id);
        }

        // DELETE api/<PatientController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await patientService.DeletePatient(id);
        }
    }
}
