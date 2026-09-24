using System.ComponentModel.DataAnnotations;
using TestWebProjec3T.Validation;

namespace TestWebProjec3T.DAL.Entites
{
    public class Employee
    {
       

        [Key]
        [Required(ErrorMessage ="Please enter id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter age")]
        [Range(18,25,ErrorMessage ="Please enter your age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(100, MinimumLength = 3)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter grade")]
        [Range(0, 4, ErrorMessage = "Please enter grade in range")]
        public double Grade { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; } = DateTime.Now;
        public DateTime? DeletedOn { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public string? Image { get; set; }
        [StringLength(150,MinimumLength =15)]
        [Required(ErrorMessage ="Please enter your address")]
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
