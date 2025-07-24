using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Core.Data
{
    public interface ISpecialtyData
    {
        IEnumerable<Specialty> GetAll();

        Specialty GetById(int id);

        Specialty GetByName(string name);

        Task AddSpecialty(Specialty specialty);

        Task UpdateSpecialty(int id, Specialty specialty);

        Task DeleteSpecialty(int id);

    }
}
