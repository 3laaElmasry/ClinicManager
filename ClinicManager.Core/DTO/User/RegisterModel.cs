using ClinicManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Core.DTO.User
{
    public class RegisterModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;


        public string FullName { get; set; } = string.Empty;

        public string? City { get; set; }

        public string? Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        public enGender Gender { get; set; }

    }
}
