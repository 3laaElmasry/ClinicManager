

using ClinicManager.Core.Entities;
using ClinicManager.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace ClinicManager.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;

        public DbSet<Appointment> Appointments { get; set; } = null!;

        public DbSet<Diagnosis> Diagnoses { get; set; } = null!;

        public DbSet<Medication> Medications { get; set; } = null!;

        public DbSet<DiagnosisMedication> DiagnosisMedications {  get; set; } = null!;


        public DbSet<Invoice> Invoices { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ApplicationRole>()
                .HasData
                (
                    new ApplicationRole
                    {
                        Id = new Guid("0a58a587-e7f7-4686-a986-6ac4f77041ee"),
                        Name = enRole.Patient.ToString(),
                        NormalizedName = enRole.Patient.ToString().ToUpper(),
                    },
                     new ApplicationRole
                     {
                         Id = new Guid("a2325752-ac16-48e9-afcf-41f069b24070"),
                         Name = enRole.Doctor.ToString(),
                         NormalizedName = enRole.Doctor.ToString().ToUpper(),
                     },
                     new ApplicationRole
                     {
                         Id = new Guid("e1471676-1fc6-467d-ada7-7abdb62a2ddd"),
                         Name = enRole.Admin.ToString(),
                         NormalizedName = enRole.Admin.ToString().ToUpper(),
                     }

                );
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }


    }
}
