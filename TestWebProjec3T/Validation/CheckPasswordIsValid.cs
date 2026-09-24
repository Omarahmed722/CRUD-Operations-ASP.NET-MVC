using System.ComponentModel.DataAnnotations;
using TestWebProjec3T.DAL.Context;

namespace TestWebProjec3T.Validation
{
    public class CheckPasswordIsValid : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? password = value as string;

            if (string.IsNullOrWhiteSpace(password))
                return new ValidationResult("Password is required");

            if (!password.Any(char.IsUpper))
                return new ValidationResult("Password must contain at least one capital letter");

            if (!password.Any(char.IsLower))
                return new ValidationResult("Password must contain at least one small letter");

            if (!password.Any(c => !char.IsLetterOrDigit(c)))
                return new ValidationResult("Password must contain at least one special character like @, $, &");

            using var db = new EmployeeDbContext();
            if (db.employees.Any(s => s.Password == password))
                return new ValidationResult("Password already exists");

            return ValidationResult.Success;
        }
    }
}
