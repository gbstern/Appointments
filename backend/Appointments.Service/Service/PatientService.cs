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
    public class PatientService : IPatientService
    {
        private readonly IPatientData patientData;
        public PatientService(IPatientData _patientData)
        {
            patientData = _patientData;
        }



        public IEnumerable<Patient> GetAll()
        {
            return patientData.GetAll();
        }

        public Patient GetById(string id)
        {
            return patientData.GetById(id);
        }

        public Patient GetByPassword(string id, string password)
        {
            return patientData.GetByPassword(id, password);
        }

        public Task AddPatient(Patient patient)
        {
            return patientData.AddPatient(patient);
        }

        public Task DeletePatient(string id)
        {
            return patientData.DeletePatient(id);
        }

        public Task UpdatePatient(Patient patient, string id)
        {
            return patientData.UpdatePatient(patient, id);
        }
    }
}
