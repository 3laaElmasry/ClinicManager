

using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.DbContext.EntitiesConfigurations
{
    public class DiagnosisMedicationConfigurations : IEntityTypeConfiguration<DiagnosisMedication>
    {
        public void Configure(EntityTypeBuilder<DiagnosisMedication> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Quantity)
                .IsRequired();


            builder.HasOne(dm => dm.Diagnosis)
                .WithMany(d => d.Medications)
                .HasForeignKey(dm => dm.DiagnosisId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(dm => dm.Medication)
                .WithMany()
                .HasForeignKey(dm => dm.MedicationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
