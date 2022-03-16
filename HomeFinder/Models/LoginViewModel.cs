using System.ComponentModel.DataAnnotations;

namespace HomeFinder.Models
{
    public class LoginViewModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm Password")]
        //[Compare("Password",
        //    ErrorMessage = "Your password does not match,")]
        //public string ConfirmPassword { get; set; }

        public bool RememberMe { get; set; }
    }
}
