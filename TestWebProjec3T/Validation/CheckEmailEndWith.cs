using System.ComponentModel.DataAnnotations;
using TestWebProjec3T.DAL.Context;

namespace TestWebProjec3T.Validation
{
    public class CheckEmailEndWith : ValidationAttribute
    {
        readonly EmployeeDbContext db;

        public CheckEmailEndWith()
        {
            db = new EmployeeDbContext();
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? email = value as string;

            if (string.IsNullOrWhiteSpace(email))
                return new ValidationResult("Email is required");

            if (!email.EndsWith(".com", StringComparison.OrdinalIgnoreCase))
                return new ValidationResult("Email must end with .com");

            if (db.employees.Any(e => e.Email == email))
                return new ValidationResult("Email already exists");

            return ValidationResult.Success;
        }
    }
}
