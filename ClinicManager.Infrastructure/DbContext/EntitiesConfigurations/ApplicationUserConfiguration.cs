using ClinicManager.Infrastructure.DbContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {

        builder.ToTable("ApplicationUsers");
        // FullName - Required + MaxLength
        builder.Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(50);

        // DateOfBirth - Required
        builder.Property(u => u.DateOfBirth)
            .IsRequired();

        // Gender - store enum as string
        builder.Property(u => u.Gender)
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(20);

        // City - Optional but limited length
        builder.Property(u => u.City)
            .HasMaxLength(50);

        // Country - Optional but limited length
        builder.Property(u => u.Country)
            .HasMaxLength(50);

        // Ignore Age (calculated property)
        builder.Ignore(u => u.Age);
    }
}
