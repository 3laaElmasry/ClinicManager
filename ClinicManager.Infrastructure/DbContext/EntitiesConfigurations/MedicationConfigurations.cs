
using ClinicManager.Infrastructure.DbContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.DbContext.EntitiesConfigurations
{
    internal class MedicationConfigurations : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.ToTable("Medications");
            builder.HasKey(x => x.Id);


            builder.Property(m => m.Name)
               .HasMaxLength(100)
               .IsRequired();

            builder.HasIndex(m => m.Name)
                .IsUnique();

            builder.Property(m => m.Name)
                .HasConversion(v => v.ToLower(), v => v);


            builder.Property(m => m.Description)
                .HasMaxLength (200)
                .IsRequired(false);

            builder.Property(m => m.Price)
                .IsRequired ()
                .HasColumnType("decimal(5,2)");

        }
    }
}
