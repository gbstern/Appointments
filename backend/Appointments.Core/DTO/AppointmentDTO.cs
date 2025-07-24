using Appointments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Core.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
    }
}
