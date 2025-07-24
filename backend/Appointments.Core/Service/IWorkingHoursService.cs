using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Core.Service
{
    public interface IWorkingHoursService
    {
        IEnumerable<WorkingHours> GetAll();

        IEnumerable<WorkingHours> GetByDoctor(string doctorId);

        WorkingHours GetByDay(string doctorId, DayOfWeek day);

        public IEnumerable<string> GetAvailableHours(string doctorId, DateTime date);

        Task AddWorkingHours(WorkingHours workingHours);

        Task UpdateWorkingHours(WorkingHours WorkingHours, int id);

        Task DeleteWorkingHours(int id);
    }
}
