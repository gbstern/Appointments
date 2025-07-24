using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Core.DTO
{
    public class SpecialtyDTO
    {
        public int Id { get; set; }
        public string specialty { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
