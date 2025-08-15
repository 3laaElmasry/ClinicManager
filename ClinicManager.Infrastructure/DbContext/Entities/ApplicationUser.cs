

using Microsoft.AspNetCore.Identity;
using ClinicManager.Core.Enums;

namespace ClinicManager.Infrastructure.DbContext.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public int Age => DateTime.Now.Year - DateOfBirth.Year -
            (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);
    }
}
