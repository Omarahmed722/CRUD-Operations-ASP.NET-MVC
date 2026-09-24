using System.ComponentModel.DataAnnotations;
using TestWebProjec3T.Validation;

namespace TestWebProjec3T.ModelVM.EmployeeVM
{
    public class CreateEmployeeVM
    {
        [Required(ErrorMessage = "Please enter age")]
        [Range(18, 25, ErrorMessage = "Please enter age in range")]
        public int Age { get; set; }
        [CheckUniqueName(ErrorMessage ="Please Enter unique name")]
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(100, MinimumLength = 3)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter grade")]
        [Range(0, 4, ErrorMessage = "Please enter grade in range")]
        public double Grade { get; set; }
        public IFormFile? Image { get; set; }
        public string Address { get; set; }
        [StringLength(20, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter your email")]
        [CheckEmailEndWith]
        public string Email { get; set; }
        [StringLength(16, MinimumLength = 8)]
        [Required(ErrorMessage = "Please enter your password")]
        [CheckPasswordIsValid]
        public string Password { get; set; }
    }
}
