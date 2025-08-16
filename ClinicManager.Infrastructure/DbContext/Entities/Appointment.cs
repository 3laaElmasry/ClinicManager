

using ClinicManager.Core.Enums;

namespace ClinicManager.Infrastructure.DbContext.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }

        public DateTime Date {  get; set; }
        
        public enAppointmentStatus Status { get; set; }

        public string Notes { get; set; } = string.Empty;

        public Guid DoctorId { get; set; }
         
        public Doctor Doctor { get; set; } = null!;
 
    }
}
