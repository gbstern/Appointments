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
    public class AppointmentController : ControllerBase
    {

        private readonly IAppointmentService appointementService;
        private readonly IMapper mapper;
        public AppointmentController(IAppointmentService _appointementService, IMapper _mapper)
        {
            appointementService = _appointementService;
            mapper = _mapper;
        }

        // GET: api/<AppointmentsController>
        [Authorize]
        [HttpGet]
        public IEnumerable<AppointmentDTO> Get()
        {
            return mapper.Map<IEnumerable<AppointmentDTO>>(appointementService.GetAll());
        }

        // GET api/<AppointmentsController>/5
        [HttpGet("id/{id}")]
        public AppointmentDTO Get(int id)
        {
            return mapper.Map<AppointmentDTO>(appointementService.GetByAppId(id));
        }

        // GET api/<AppointmentsController>/5
        [HttpGet("patient/{patientId}")]
        public IEnumerable<AppointmentDTO> GetBypatient(string patientId)
        {
            return mapper.Map<IEnumerable<AppointmentDTO>>(appointementService.GetByPatient(patientId));
        }


        // GET api/<AppointmentsController>/5
        [Authorize]
        [HttpGet("doctor/{doctorId}")]
        public IEnumerable<AppointmentDTO> GetByDoctor(string doctorId)
        {
            return mapper.Map<IEnumerable<AppointmentDTO>>(appointementService.GetByDoctor(doctorId));
        }

        // GET api/<AppointmentsController>/5
        [Authorize]
        [HttpGet("date/{date}")]
        public IEnumerable<AppointmentDTO> GetByDate(DateTime date)
        {
            return mapper.Map<IEnumerable<AppointmentDTO>>(appointementService.GetByDate(date));
        }


        // POST api/<AppointmentsController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Appointment appointment)
        {
            var result = appointementService.AddAppointment(appointment);
            if (result.Success) // אם result הוא ValueTuple, גישה לערך הראשון
                return Ok(appointment);
            return BadRequest(new { message = result.Message });
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Appointment appointment)
        {
            await appointementService.UpdateAppointment(appointment, id);
        }

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await appointementService.DeleteAppointment(id);
        }
    }
}
