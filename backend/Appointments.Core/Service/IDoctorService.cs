using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Core.Service
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetAll();

        IEnumerable<Doctor> GetBySpecialty(int specialtyId);

        Doctor GetById(string Id);

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
