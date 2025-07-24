using Appointments.Core.Data;
using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Data.Data
{
    public class WorkingHoursData : IWorkingHoursData
    {
        public readonly DataContext dataContext;
        public WorkingHoursData(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        public IEnumerable<WorkingHours> GetAll()
        {
            return dataContext.workingHours;
        }

        public WorkingHours GetByDay(string doctorId, DayOfWeek day)
        {
            return dataContext.workingHours.FirstOrDefault(w => w.DoctorId == doctorId && w.Day ==  day);
        }

        public IEnumerable<string> GetAvailableHours(string doctorId, DateTime date)
        {
            Console.WriteLine("date: {date}, date.DayOfWeek: {date.DayOfWeek}");
            var workingHours = GetByDay(doctorId, date.DayOfWeek);
            var appointments = dataContext.appointments.Where(a => a.DoctorId == doctorId && a.Date.Date == date.Date).Select(a => a.Hour).ToList();

            var doctor = dataContext.doctors.FirstOrDefault(d => d.Id == doctorId); // קבל את הרופא
            var appointmentDuration = doctor?.AppDoration ?? TimeSpan.FromMinutes(15);

            var availableHours = new List<string>();
            if (workingHours != null)
            {
                for (var hour = workingHours.StartTime; hour <= workingHours.EndTime; hour = hour.Add(appointmentDuration)) // נניח תור כל 30 דקות
                {
                    if (!appointments.Contains(hour))
                    {
                        availableHours.Add(hour.ToString(@"hh\:mm"));
                    }
                }
            }
            return availableHours;
        }

        public IEnumerable<WorkingHours> GetByDoctor(string doctorId)
        {
            return dataContext.workingHours.Where(w => w.DoctorId == doctorId);
        }

        public async Task AddWorkingHours(WorkingHours wh)
        {
            var w = dataContext.workingHours.FirstOrDefault(w => w.DoctorId == wh.DoctorId && w.Day == wh.Day);
            var d = dataContext.doctors.FirstOrDefault(d => d.Id.Equals(wh.DoctorId));
            if (w == null && d != null)
            {
                dataContext.workingHours.Add(wh);
                d.WorkingHours ??= new List<WorkingHours>();
                d.WorkingHours.Add(wh);
            }     
            await dataContext.SaveChangesAsync();
        }
        public async Task UpdateWorkingHours(WorkingHours WorkingHours, int id)
        {
            var w = dataContext.workingHours.FirstOrDefault(w => w.Id == id);
            if (w != null)
            {
                w.StartTime = WorkingHours.StartTime;
                w.EndTime = WorkingHours.EndTime;
            }
            await dataContext.SaveChangesAsync();
        }

        public async Task DeleteWorkingHours(int id)
        {
            var w = dataContext.workingHours.FirstOrDefault(w => w.Id == id);
            if (w != null)
                dataContext.workingHours.Remove(w);
            await dataContext.SaveChangesAsync();
        }
    }
}
