using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Core.Data
{
    public interface IAppointmentData
    {
        IEnumerable<Appointment> GetAll();

        Appointment GetByAppId(int id);

        IEnumerable<Appointment> GetByPatient(string patientId);

        IEnumerable<Appointment> GetByDoctor(string doctorId);

        IEnumerable<Appointment> GetByDate(DateTime date);

        (bool Success, string Message) AddAppointment(Appointment appointment);

        Task UpdateAppointment(Appointment appointment, int id);

        Task DeleteAppointment(int id);
    }
}
