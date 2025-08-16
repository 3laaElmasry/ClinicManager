

namespace ClinicManager.Infrastructure.DbContext.Entities
{
    public class DiagnosisMedication
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public Guid DiagnosisId { get; set; }

        public Diagnosis Diagnosis { get; set; } = null!;
    }
}
