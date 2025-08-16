
namespace ClinicManager.Infrastructure.DbContext.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
