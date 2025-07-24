using Appointments.Core.DTO;
using Appointments.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Core
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Specialty, SpecialtyDTO>().ReverseMap();
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<WorkingHours, WorkingHoursDTO>().ReverseMap();
        }
    }
}
