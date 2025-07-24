using Appointments.Core.Data;
using Appointments.Core.Entities;
using Appointments.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Service.Service
{
    public class WorkingHoursService : IWorkingHoursService
    {
        private readonly IWorkingHoursData workingHoursData;
        public WorkingHoursService(IWorkingHoursData _workingHoursData)
        {
            workingHoursData = _workingHoursData;
        }



        public IEnumerable<WorkingHours> GetAll()
        {
            return workingHoursData.GetAll();
        }

        public WorkingHours GetByDay(string doctorId, DayOfWeek day)
        {
            return workingHoursData.GetByDay(doctorId, day);
        }

        public IEnumerable<string> GetAvailableHours(string doctorId, DateTime date)
        {
            return workingHoursData.GetAvailableHours(doctorId, date);
        }

        public IEnumerable<WorkingHours> GetByDoctor(string doctorId)
        {
            return workingHoursData.GetByDoctor(doctorId);
        }


        public Task AddWorkingHours(WorkingHours workingHours)
        {
            return workingHoursData.AddWorkingHours(workingHours);
        }

        public Task DeleteWorkingHours(int id)
        {
            return workingHoursData.DeleteWorkingHours(id);
        }
        public Task UpdateWorkingHours(WorkingHours WorkingHours, int id)
        {
            return workingHoursData.UpdateWorkingHours(WorkingHours, id);
        }
    }
}
