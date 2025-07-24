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
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentData appointmentData;

        public AppointmentService(IAppointmentData _appointmentData)
        {
            appointmentData = _appointmentData;
        }



        public IEnumerable<Appointment> GetAll()
        {
            return appointmentData.GetAll();
        }

        public Appointment GetByAppId(int id)
        {
            return appointmentData.GetByAppId(id);
        }

        public IEnumerable<Appointment> GetByDate(DateTime date)
        {
            return appointmentData.GetByDate(date);
        }

        public IEnumerable<Appointment> GetByDoctor(string doctorId)
        {
            return appointmentData.GetByDoctor(doctorId);
        }

        public IEnumerable<Appointment> GetByPatient(string patientId)
        {
            return appointmentData.GetByPatient(patientId);
        }

        public (bool Success, string Message) AddAppointment(Appointment appointment)
        {
            return appointmentData.AddAppointment(appointment);
        }

        public Task DeleteAppointment(int id)
        {
            return appointmentData.DeleteAppointment(id);
        }

        public Task UpdateAppointment(Appointment appointment, int id)
        {
            return appointmentData.UpdateAppointment(appointment, id);
        }
    }
}
