
namespace ClinicManager.Core.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }


        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;

         
        public string InsuranceNumber { get; set; } = string.Empty;


        public IEnumerable<Appointment> Appointments { get; set; } = null!;


    }

}
