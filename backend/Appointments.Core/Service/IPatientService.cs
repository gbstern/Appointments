using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Core.Service
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAll();

        Patient GetByPassword(string id, string password);

        Patient GetById(string id);

        Task AddPatient(Patient patient);

        Task UpdatePatient(Patient patient, string id);

        Task DeletePatient(string id);
    }
}
