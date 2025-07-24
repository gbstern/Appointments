using Appointments.Core.Data;
using Appointments.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Data.Data
{
    public class AppointmentData : IAppointmentData
    {
        public readonly DataContext dataContex;
        public AppointmentData(DataContext _dataContex)
        {
            dataContex = _dataContex;
        }



        public IEnumerable<Appointment> GetAll()
        {
            return dataContex.appointments;
        }

        public Appointment GetByAppId(int id)
        {
            return dataContex.appointments.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Appointment> GetByDate(DateTime date)
        {
            return dataContex.appointments.Where(a => a.Date.Equals(date.Date));
        }

        public IEnumerable<Appointment> GetByDoctor(string doctorId)
        {
            return dataContex.appointments.Where(a => a.DoctorId.Equals(doctorId));
        }

        public IEnumerable<Appointment> GetByPatient(string patientId)
        {
            return dataContex.appointments.Where(a => a.PatientId.Equals(patientId));
        }

        public (bool Success, string Message) AddAppointment(Appointment app)
        {
            TimeSpan hour;
            if (!TimeSpan.TryParse(app.Hour.ToString(), out hour))
            {
                return (false, "Invalid hour format.");
            }

            var a = dataContex.appointments.FirstOrDefault(a => a.DoctorId.Equals(app.DoctorId) && a.Date.Equals(app.Date) && a.Hour.Equals(app.Hour));
            var d = dataContex.doctors.FirstOrDefault(d => d.Id.Equals(app.DoctorId));
            var p = dataContex.patients.FirstOrDefault(p => p.Id.Equals(app.PatientId));

            if (a != null)
            {
                return (false, "Appointment already exists.");
            }
            if (d == null)
            {
                return (false, "Doctor not found.");
            }
            if (p == null)
            {
                return (false, "Patient not found.");
            }

            var workingHours = dataContex.workingHours.FirstOrDefault(w => w.DoctorId == app.DoctorId && w.Day == app.Date.DayOfWeek);
            if (workingHours == null || app.Hour < workingHours.StartTime || app.Hour > workingHours.EndTime)
            {
                return (false, "Appointment time is outside of working hours.");
            }

            dataContex.appointments.Add(app);
            d.Appointments ??= new List<Appointment>();
            d.Appointments.Add(app);
            p.Appointments ??= new List<Appointment>();
            p.Appointments.Add(app);
            dataContex.SaveChanges();

            return (true, "Appointment added successfully.");
        }

        public async Task UpdateAppointment(Appointment app, int id)
        {
            var a = dataContex.appointments.FirstOrDefault(x => x.Id == id);
            if (a != null)
            {
                var workingHours = dataContex.workingHours.FirstOrDefault(w => w.DoctorId == app.DoctorId && w.Day == app.Date.DayOfWeek);
                if (workingHours != null && app.Hour >= workingHours.StartTime && app.Hour <= workingHours.EndTime)
                {
                    a.Date = app.Date;
                    a.Hour = app.Hour;
                }
            }
            await dataContex.SaveChangesAsync();
        }


        public async Task DeleteAppointment(int id)
        {
            var a = dataContex.appointments.FirstOrDefault(a => a.Id == id);
            if (a != null)
                dataContex.appointments.Remove(a);
            await dataContex.SaveChangesAsync();
        }
    }
}

