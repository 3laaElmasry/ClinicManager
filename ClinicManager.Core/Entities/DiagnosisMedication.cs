



namespace ClinicManager.Core.Entities
{
    public class DiagnosisMedication
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public Guid DiagnosisId { get; set; }
        public Guid MedicationId { get; set; }

        public Diagnosis Diagnosis { get; set; } = null!;
        public Medication Medication { get; set; } = null!;
    }
}
