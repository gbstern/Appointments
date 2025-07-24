using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Core.Data
{
    public interface IDoctorData
    {
        IEnumerable<Doctor> GetAll();

        IEnumerable<Doctor> GetBySpecialty(int specialtyId);

        Doctor GetById(string id);

        Doctor GetByName(string doctorName);

        //??
        IEnumerable<Doctor> GetByGender(Gender doctorGender);

        //??
        IEnumerable<Doctor> GetByLanguage(string language);

        bool AddDoctor(Doctor doctor);

        Task UpdateDoctor(Doctor doctor, string id);

        Task DeleteDoctor(string id);
    }
}
