
namespace ClinicManager.Infrastructure.DbContext.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime PaymentDate { get; set; }


        public Guid DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; } = null!;

    }
}
