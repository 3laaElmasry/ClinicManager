

using ClinicManager.Core.Common.Attriputes;
using ClinicManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicManager.Core.DTO.User
{
    public class RegisterPatientDto
    {


        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50,MinimumLength = 3, ErrorMessage = "Full Name must be between {1} and {0} characters")]
        public string FullName { get; set; } = string.Empty;

        [MinAge(6)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [EnumDataType(typeof(enGender), ErrorMessage = "Gender must be either Male or Female.")]
        public enGender Gender { get; set; }


        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        [StringLength(50)]
        public string Country { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d).{6,}$",
    ErrorMessage = "Password must contain at least one letter and one number.")]
        [DataType(DataType.Password)]

        public string Password { get; set; } = string.Empty;

        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [StringLength(50)]
        public string? InsuranceName { get; set; }

    }

}
