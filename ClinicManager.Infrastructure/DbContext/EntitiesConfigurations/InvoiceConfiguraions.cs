
using ClinicManager.Infrastructure.DbContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.DbContext.EntitiesConfigurations
{
    public class InvoiceConfiguraions : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");
           builder.HasKey(x => x.Id);

            builder.Property(i => i.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(i => i.PaymentDate)
                .IsRequired();


            builder.HasOne(i => i.Diagnosis)
                .WithOne(i => i.Invoice)
                .HasForeignKey<Invoice>(i => i.DiagnosisId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
