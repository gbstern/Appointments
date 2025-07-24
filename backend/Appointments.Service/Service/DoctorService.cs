using Appointments.Core;
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
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorData doctorData;
        public DoctorService(IDoctorData _doctorData)
        {
            doctorData = _doctorData;
        }



        public IEnumerable<Doctor> GetAll()
        {
            return doctorData.GetAll();
        }

        public IEnumerable<Doctor> GetByGender(Gender doctorGender)
        {
            return doctorData.GetByGender(doctorGender);
        }

        public IEnumerable<Doctor> GetByLanguage(string language)
        {
            return doctorData.GetByLanguage(language);
        }

        public Doctor GetById(string id)
        {
            return doctorData.GetById(id);
        }

        public Doctor GetByName(string doctorName)
        {
            return doctorData.GetByName(doctorName);
        }

        public IEnumerable<Doctor> GetBySpecialty(int specialtyId)
        {
            return doctorData.GetBySpecialty(specialtyId);
        }

        public Task UpdateDoctor(Doctor doctor, string id)
        {
            return doctorData.UpdateDoctor(doctor, id);
        }

        public bool AddDoctor(Doctor doctor)
        {
            return doctorData.AddDoctor(doctor);
        }

        public Task DeleteDoctor(string id)
        {
            return doctorData.DeleteDoctor(id);
        }
    }
}
