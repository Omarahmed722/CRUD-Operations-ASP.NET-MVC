using System.ComponentModel.DataAnnotations;
using TestWebProjec3T.DAL.Context;

namespace TestWebProjec3T.Validation
{
    public class CheckUniqueName: ValidationAttribute
    {
        readonly EmployeeDbContext db;
        public CheckUniqueName()
        {
            db = new EmployeeDbContext();
        }
        protected override ValidationResult IsValid(object? value,ValidationContext validationContext)
        {
            string name = value as string;
            var check = db.employees.Where(a => a.Name.ToLower() == name.ToLower()).FirstOrDefault();
            if (check != null) 
            {
                return new ValidationResult("Name must be unique");
            }
            else
            {
                return ValidationResult.Success ;
            }
        }
    }
}
