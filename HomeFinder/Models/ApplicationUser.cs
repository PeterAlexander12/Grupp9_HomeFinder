using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HomeFinder.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }

        //[Display(Name ="Användarnamn")]
        //public string? UserName { get; set; }

        //[Required]
        [Display(Name = "Given name")]
        public string GivenName { get; set; }
        //[Required]
        [Display(Name = "Surname")]
        public string SurName { get; set; }

        //[Phone]
        //[Display(Name = "Telefonnummer")]
        //public string? PhoneNumber { get; set; }

        //[Required]
        //[Display(Name = "Lösenord")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "Your password does not match,")]
        public string ConfirmPassword { get; set; }

    }
}
