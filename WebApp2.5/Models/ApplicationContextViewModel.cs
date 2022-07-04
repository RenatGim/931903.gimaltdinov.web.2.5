using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApp2._5.Models
{
    public class ApplicationContextViewModel : DbContext
    {
        public DbSet<HospitalViewModel> Hospital { get; set; }
        public DbSet<LabsViewModel> Labs { get; set; }
        public DbSet<DoctorViewModel> Doctors { get; set; }
        public DbSet<PatientsViewModel> Patients { get; set; }

        public ApplicationContextViewModel(DbContextOptions<ApplicationContextViewModel> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
