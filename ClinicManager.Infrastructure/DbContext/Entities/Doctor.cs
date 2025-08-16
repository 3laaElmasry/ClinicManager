

namespace ClinicManager.Infrastructure.DbContext.Entities
{
    public class Doctor
    {
        public Guid Id { get; set; }


        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;
        public string LicenseNumber { get; set; } = string.Empty;


        public IEnumerable<Appointment> Appointments { get; set; } = null!;

    }

}
