using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Core.Entities
{
    public class Specialty
    {
        public int Id { get; set; }
        public string specialty { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
