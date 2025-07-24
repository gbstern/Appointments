using Appointments.Core.Data;
using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Data.Data
{
    public class PatientData : IPatientData
    {
        public readonly DataContext dataContex;
        public PatientData(DataContext _dataContex)
        {
            dataContex = _dataContex;
        }



        public IEnumerable<Patient> GetAll()
        {
            return dataContex.patients;
        }

        public Patient GetById(string id)
        {
            return dataContex.patients.FirstOrDefault(p => p.Id == id);
        }

        public Patient GetByPassword(string id, string password)
        {
            return dataContex.patients.FirstOrDefault(p => p.Id == id && p.Password == password);
        }

        public async Task AddPatient(Patient patient)
        {
            var p = dataContex.patients.FirstOrDefault(p => p.Id.Equals(patient.Id));
            if (p == null)
                dataContex.patients.Add(patient);
            await dataContex.SaveChangesAsync();
        }

        public async Task UpdatePatient(Patient patient, string id)
        {
            var p = dataContex.patients.FirstOrDefault(p => p.Id.Equals(patient.Id));
            if (p != null)
            {
                p.FirstName = patient.FirstName;
                p.LastName = patient.LastName;
                p.Address = patient.Address;
                p.Email = patient.Email;
                p.Phone = patient.Phone;
                p.Password = patient.Password;
            }
            await dataContex.SaveChangesAsync();
        }

        public async Task DeletePatient(string id)
        {
            var p = dataContex.patients.FirstOrDefault(p => p.Id.Equals(id));
            if (p != null)
                dataContex.patients.Remove(p);
            await dataContex.SaveChangesAsync();
        }
    }
}
