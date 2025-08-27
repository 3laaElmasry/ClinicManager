
namespace ClinicManager.Core.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }


        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;


        public string? InsuranceName { get; set; } = null;


        public IEnumerable<Appointment> Appointments { get; set; } = null!;


    }

}
