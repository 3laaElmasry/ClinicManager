

using System.Reflection.Emit;

namespace ClinicManager.Infrastructure.DbContext.Entities
{
    public class Diagnosis
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime Date {  get; set; }


        public Guid AppointmentId { get; set; }

        public Appointment Appointment { get; set; } = null!;

        public IEnumerable<DiagnosisMedication> Medications { get; set; } = null!;
    }
}
