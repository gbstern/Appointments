using Appointments.Core.Data;
using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Data.Data
{
    public class SpecialtyData : ISpecialtyData
    {
        public readonly DataContext dataContex;
        public SpecialtyData(DataContext _dataContex)
        {
            dataContex = _dataContex;
        }


        public IEnumerable<Specialty> GetAll()
        {
            return dataContex.specialties;
        }

        public Specialty GetById(int id)
        {
            return dataContex.specialties.FirstOrDefault(s => s.Id == id);
        }

        public Specialty GetByName(string name)
        {
            return dataContex.specialties.FirstOrDefault(s => s.specialty.Equals(name));
        }

        public async Task AddSpecialty(Specialty specialty)
        {
            var s = dataContex.specialties.FirstOrDefault(x => x.Id == specialty.Id);
            if (s == null)
                dataContex.specialties.Add(specialty);
            await dataContex.SaveChangesAsync();
        }

        public async Task UpdateSpecialty(int id, Specialty specialty)
        {
            var s = dataContex.specialties.FirstOrDefault(x => x.Id == id)!;
            if (s != null)
                s.specialty = specialty.specialty;
            await dataContex.SaveChangesAsync();
        }

        public async Task DeleteSpecialty(int id)
        {
            var s = dataContex.specialties.FirstOrDefault(x => x.Id == id)!;
            if (s != null)
                dataContex.specialties.Remove(s);
            await dataContex.SaveChangesAsync();
        }

    }
}
