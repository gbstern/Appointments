using Appointments.Core;
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
    public class DoctorData : IDoctorData
    {
        public readonly DataContext dataContex;
        public DoctorData(DataContext _dataContex)
        {
            dataContex = _dataContex;
        }


        public IEnumerable<Doctor> GetAll()
        {
            return dataContex.doctors;
        }

        public IEnumerable<Doctor> GetByGender(Gender doctorGender)
        {
            return dataContex.doctors.Where(d => d.gender == doctorGender);
        }

        public IEnumerable<Doctor> GetByLanguage(string language)
        {
            return dataContex.doctors.Where(d => d.languages.Contains(language));
        }

        public Doctor GetById(string id)
        {
            Console.WriteLine(dataContex.doctors.FirstOrDefault(d => d.Id == id));
            return dataContex.doctors.FirstOrDefault(d => d.Id == id);
        }

        public Doctor GetByName(string doctorName)
        {
            return dataContex.doctors.FirstOrDefault(d => d.Name == doctorName);
        }

        public IEnumerable<Doctor> GetBySpecialty(int specialtyId)
        {
            return dataContex.doctors.Where(d => d.specialtyId == specialtyId);
        }

        public bool AddDoctor(Doctor doctor)
        {
            var d = dataContex.doctors.FirstOrDefault(d => d.Id == doctor.Id);
            var sp = dataContex.specialties.FirstOrDefault(s => s.Id == doctor.specialtyId);
            if (d == null && sp != null)
            {
                dataContex.doctors.Add(doctor);
                sp.Doctors ??= new List<Doctor>();
                sp.Doctors.Add(doctor);
                dataContex.SaveChangesAsync();
                return true;
            }
            else
                return false;
                
            
        }

        public async Task UpdateDoctor(Doctor doctor, string id)
        {
            var d = dataContex.doctors.FirstOrDefault(d => d.Id == doctor.Id);
            if (d != null)
            {
                d.Name = doctor.Name;
                d.specialtyId = doctor.specialtyId;
                d.gender = doctor.gender;
                d.languages = doctor.languages;
                d.Phone = doctor.Phone;
                d.Email = doctor.Email;
                d.AppDoration = doctor.AppDoration;
                d.WorkingHours = doctor.WorkingHours;
            }
            await dataContex.SaveChangesAsync();
        }

        public async Task DeleteDoctor(string id)
        {
            var d = dataContex.doctors.FirstOrDefault(d => d.Id == id);
            if (d != null)
                dataContex.doctors.Remove(d);
            await dataContex.SaveChangesAsync();
        }
    }


}
