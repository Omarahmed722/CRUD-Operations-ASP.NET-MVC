using System.ComponentModel.DataAnnotations;
using TestWebProjec3T.Validation;

namespace TestWebProjec3T.ModelVM.EmployeeVM
{
    public class GetEmployeeVM
    {
        [Key]
        [Required(ErrorMessage = "Please enter id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter age")]
        [Range(18, 25, ErrorMessage = "Please enter your age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(100, MinimumLength = 3)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter grade")]
        [Range(0, 4, ErrorMessage = "Please enter grade in range")]
        public double Grade { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? Image { get; set; }
        public string Address { get; set; }
        [StringLength(50, MinimumLength = 20)]
        [Required(ErrorMessage = "Please enter your email")]
        [CheckEmailEndWith]
        public string Email { get; set; }


    }
}
