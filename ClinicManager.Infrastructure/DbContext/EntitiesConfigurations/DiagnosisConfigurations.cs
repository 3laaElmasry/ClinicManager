

using ClinicManager.Infrastructure.DbContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.DbContext.EntitiesConfigurations
{
    public class DiagnosisConfigurations : IEntityTypeConfiguration<Diagnosis>
    {
        public void Configure(EntityTypeBuilder<Diagnosis> builder)
        {
            builder.ToTable("Diagnoses");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Description)
                .HasMaxLength(250)
                .IsRequired(true);

            builder.Property(d => d.Date)
                .IsRequired();
            


            builder.HasOne(d => d.Appointment)
                .WithMany(a => a.Diagnoses)
                .HasForeignKey(d =>  d.AppointmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
