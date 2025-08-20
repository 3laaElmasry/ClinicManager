
namespace ClinicManager.Core.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }


        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public string MedicalRecordNumber { get; set; } = string.Empty;
        public string InsuranceProvider { get; set; } = string.Empty;  
        public string InsuranceNumber { get; set; } = string.Empty;


        public IEnumerable<Appointment> Appointments { get; set; } = null!;


    }

}
