using HMS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HMS.Data
{
    public class HMSDbContext : DbContext
    {
        public HMSDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Appointments)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);


            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Phones)
                .WithOne()
                .HasForeignKey(p => p.PatientId);

            modelBuilder.Entity<Patient>()
                .HasIndex(p => p.Email)
                .IsUnique();

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.MedicalRecord)
                .WithOne(p => p.Patient)
                .HasForeignKey<MedicalRecord>(m => m.PatientId);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Department)
                .WithMany(d => d.Doctors)
                .HasForeignKey(d => d.DepartmentId);

            modelBuilder.Entity<Doctor>()
                .HasIndex(d => d.Email)
                .IsUnique();

            modelBuilder.Entity<Doctor>()
                .Property(d => d.Salary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Department>()
                .HasIndex(d => d.Name)
                .IsUnique();


            // Data Seeding

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Cardiology (القلب)" },
                new Department { Id = 2, Name = "Pediatrics (الأطفال)" },
                new Department { Id = 3, Name = "Orthopedics (العظام)" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Dr. Ahmed Mansour", Specialization = "Consultant", Email = "ahmed@hms.com", Salary = 45000m, DepartmentId = 1 },
                new Doctor { Id = 2, Name = "Dr. Mona Abdel-Aziz", Specialization = "Surgeon", Email = "mona@hms.com", Salary = 38000m, DepartmentId = 2 },
                new Doctor { Id = 3, Name = "Dr. Tarek El-Shennawy", Specialization = "Specialist", Email = "tarek@hms.com", Salary = 42000m, DepartmentId = 3 },         
                new Doctor { Id = 4, Name = "Dr. Khaled Hassan", Specialization = "Cardiologist", Email = "khaled@hms.com", Salary = 40000m, DepartmentId = 1 },
                new Doctor { Id = 5, Name = "Dr. Fatma El-Zahraa", Specialization = "Pediatrician", Email = "fatma@hms.com", Salary = 37000m, DepartmentId = 2 }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Mohamed Youssef El-Sherif", Email = "m.youssef@gmail.com", DateOfBirth = new DateTime(1985, 5, 12) },
                new Patient { Id = 2, FullName = "Sara Mahmoud Ibrahim", Email = "sara.m88@yahoo.com", DateOfBirth = new DateTime(1992, 10, 25) },
                new Patient { Id = 3, FullName = "Omar Khaled El-Fayoumy", Email = "omar.fayoumy@outlook.com", DateOfBirth = new DateTime(2015, 3, 14) },
                new Patient { Id = 4, FullName = "Layla Ahmed Mahmoud", Email = "layla.a@gmail.com", DateOfBirth = new DateTime(1990, 8, 5) },
                new Patient { Id = 5, FullName = "Hassan Ali Mansour", Email = "hassan.ali@gmail.com", DateOfBirth = new DateTime(1978, 12, 20) }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, PatientId = 1, DoctorId = 1, AppointmentDate = DateTime.Now.AddDays(-5), Status = "Completed", Notes = "Checkup" },
                new Appointment { Id = 4, PatientId = 2, DoctorId = 1, AppointmentDate = DateTime.Now.AddDays(-3), Status = "Completed", Notes = "Follow-up" },
                new Appointment { Id = 5, PatientId = 4, DoctorId = 4, AppointmentDate = DateTime.Now.AddDays(1), Status = "Scheduled", Notes = "New Patient" },

                new Appointment { Id = 2, PatientId = 3, DoctorId = 2, AppointmentDate = DateTime.Now.AddDays(2), Status = "Scheduled", Notes = "Vaccination" },
                new Appointment { Id = 6, PatientId = 5, DoctorId = 5, AppointmentDate = DateTime.Now.AddDays(-1), Status = "Completed", Notes = "Routine check" },
                new Appointment { Id = 7, PatientId = 3, DoctorId = 5, AppointmentDate = DateTime.Now.AddDays(10), Status = "Scheduled", Notes = "Monthly review" },

                new Appointment { Id = 3, PatientId = 2, DoctorId = 3, AppointmentDate = DateTime.Now.AddDays(-20), Status = "Completed", Notes = "Post-surgery" }
            );

            modelBuilder.Entity<PatientPhones>().HasData(
                new PatientPhones { Id = 1, PhoneNumber = "01012345678", PatientId = 1 },
                new PatientPhones { Id = 2, PhoneNumber = "01198765432", PatientId = 1 },
                new PatientPhones { Id = 3, PhoneNumber = "01255544433", PatientId = 2 },
                new PatientPhones { Id = 4, PhoneNumber = "01500011122", PatientId = 3 },
                new PatientPhones { Id = 5, PhoneNumber = "01099988877", PatientId = 4 },
                new PatientPhones { Id = 6, PhoneNumber = "01122233344", PatientId = 5 }
            );

            modelBuilder.Entity<MedicalRecord>().HasData(
                new MedicalRecord { Id = 1, PatientId = 1, Diagnosis = "Hypertension", Treatment = "Meds", LastUpdated = new DateTime(2026, 01, 15) },
                new MedicalRecord { Id = 2, PatientId = 2, Diagnosis = "ACL Repair", Treatment = "PT", LastUpdated = new DateTime(2026, 02, 10) },
                new MedicalRecord { Id = 3, PatientId = 4, Diagnosis = "Seasonal Allergy", Treatment = "Antihistamines", LastUpdated = new DateTime(2026, 03, 01) }
            );

        }


        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientPhones> PatientPhones { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
    }
}
