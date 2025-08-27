

using ClinicManager.Core.Common.Attriputes;

using ClinicManager.Core.Enums;
using System.ComponentModel.DataAnnotations;


namespace ClinicManager.Core.DTO.User
{
    public class RegisterPatient
    {


        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50,MinimumLength = 3, ErrorMessage = "Full Name must be between {1} and {0} characters")]
        public string FullName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [MinAge(6)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public enGender Gender { get; set; }


        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        [StringLength(50)]
        public string Country { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(
        pattern: @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$",
    ErrorMessage = "Password must be at least 6 characters and include at least one uppercase, one lowercase.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [StringLength(50)]
        public string? InsuranceName { get; set; }

    }

}
