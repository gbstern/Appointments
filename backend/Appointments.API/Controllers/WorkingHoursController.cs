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
    public class WorkingHoursController : ControllerBase
    {
        private readonly IWorkingHoursService workingHoursService;
        private readonly IMapper mapper;

        public WorkingHoursController(IWorkingHoursService _workingHoursService, IMapper _mapper)
        {
            workingHoursService = _workingHoursService;
            mapper = _mapper;
        }


        // GET: api/<WorkingHoursController>
        [HttpGet]
        public IEnumerable<WorkingHoursDTO> Get()
        {
            return mapper.Map<IEnumerable<WorkingHoursDTO>>(workingHoursService.GetAll());
        }

        // GET: api/<WorkingHoursController/1234>
        [HttpGet("{id}")]
        public IEnumerable<WorkingHoursDTO> GetByDoctor(string id)
        {
            return mapper.Map<IEnumerable<WorkingHoursDTO>>(workingHoursService.GetByDoctor(id));
        }

        // GET api/<WorkingHoursController>/5
        [HttpGet("id/{id}/day/{day}")]
        public WorkingHoursDTO GetByDay(string id, DayOfWeek day)
        {
            return mapper.Map<WorkingHoursDTO>(workingHoursService.GetByDay(id, day));
        }


        // GET api/<WorkingHoursController>/5
        [HttpGet("id/{id}/date/{date}")]
        public IEnumerable<string> GetAvailableHours(string id, DateTime date)
        {
            return mapper.Map<IEnumerable<string>>(workingHoursService.GetAvailableHours(id, date));
        }

        // POST api/<WorkingHoursController>
        [Authorize]
        [HttpPost]
        public async Task Post([FromBody] WorkingHours workingHours)
        {
            await workingHoursService.AddWorkingHours(workingHours);
        }

        // PUT api/<WorkingHoursController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] WorkingHours workingHours)
        {
            await workingHoursService.UpdateWorkingHours(workingHours, id);
        }

        // DELETE api/<WorkingHoursController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await workingHoursService.DeleteWorkingHours(id);
        }
    }
}
