using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointments.Core.Data;
using Appointments.Core.Entities;
using Appointments.Core.Service;

namespace Appointments.Service.Service
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly ISpecialtyData specialtyData;

        public SpecialtyService(ISpecialtyData _specialtyData)
        {
            specialtyData = _specialtyData;
        }


        public IEnumerable<Specialty> GetAll()
        {
            return specialtyData.GetAll();
        }

        public Specialty GetById(int id)
        {
            return specialtyData.GetById(id);
        }

        public Specialty GetByName(string name)
        {
            return specialtyData.GetByName(name);
        }

        public Task AddSpecialty(Specialty specialty)
        {
            return specialtyData.AddSpecialty(specialty);
        }

        public Task DeleteSpecialty(int id)
        {
            return specialtyData.DeleteSpecialty(id);
        }


        public Task UpdateSpecialty(int id, Specialty specialty)
        {
            return specialtyData.UpdateSpecialty(id, specialty);
        }
    }
}
