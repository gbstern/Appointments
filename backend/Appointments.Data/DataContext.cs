using Appointments.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Specialty> specialties { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<WorkingHours> workingHours { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Appointment> appointments { get; set; }


        IConfiguration configuration { get; set; }
        public DataContext(DbContextOptions<DataContext> option, IConfiguration _configuration) : base(option)
        {
            configuration = _configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //לקובץ חיצוני connection string-הוצאת ה 
            optionsBuilder.UseSqlServer(configuration["DBConnectionString"]);
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=mydb");
        }
    }
}
