using ClinicManager.Infrastructure.DbContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        
        builder.ToTable("Doctors");

        builder.HasKey(d => d.Id);

        
        builder.Property(d => d.LicenseNumber)
            .HasMaxLength(50)
            .IsRequired();

       
        builder.HasOne(d => d.ApplicationUser)
            .WithOne()
            .HasForeignKey<Doctor>(d => d.ApplicationUserId)
            .OnDelete(DeleteBehavior.Cascade);

      
    }
}
