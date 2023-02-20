using HealthPlus.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace HealthPlus.Infrastructure.Persistence.Context
{
    public class HealthPlusContext : DbContext

    {
        public HealthPlusContext(DbContextOptions<HealthPlusContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<HospitalService> HospitalServices { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
