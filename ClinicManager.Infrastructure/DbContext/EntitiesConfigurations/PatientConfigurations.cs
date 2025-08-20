
using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.DbContext.EntitiesConfigurations
{
    public class PatientConfigurations : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.ApplicationUser)
                   .WithOne()
                   .HasForeignKey<Patient>(p => p.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.Property(p => p.MedicalRecordNumber)
                   .HasMaxLength(50)
                   .IsRequired();


            builder.Property(p => p.InsuranceProvider)
                   .HasMaxLength(100);

            
            builder.Property(p => p.InsuranceNumber)
                   .HasMaxLength(50);

           
        }
    }
}
