using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Core.DTO
{
    public class DoctorDTO
    {
        public string Id { get; set; }
        public string LicenseNum { get; set; }
        public string Name { get; set; }
        public int specialtyId { get; set; }
        public Gender gender { get; set; }
        public string languages { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<WorkingHours> WorkingHours { get; set; }
        public TimeSpan AppDoration { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}