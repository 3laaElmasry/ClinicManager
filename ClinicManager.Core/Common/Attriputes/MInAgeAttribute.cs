
using System.ComponentModel.DataAnnotations;

namespace ClinicManager.Core.Common.Attriputes
{
    public class MinAgeAttribute : ValidationAttribute
    {
        private readonly int _minAge;

        public MinAgeAttribute(int minAge,string userName = "Patient")
        {
            _minAge = minAge;

            ErrorMessage = $"{userName} must be at least {_minAge} years old";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is not DateTime date)
            {
                return new ValidationResult("Ivalid date format.");
            }

            var age = DateTime.Now.Year - date.Year;

            return age >= _minAge ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
}
