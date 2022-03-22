using System.ComponentModel.DataAnnotations;

namespace HomeFinder.Models
{
    public class User
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name ="Användarnamn")]
        public string? UserName { get; set; }

        [Required]
        [Display(Name = "Förnamn")]
        public string GivenName { get; set; }
        [Required]
        [Display(Name = "Efternamn")]
        public string SurName { get; set; }

        [Phone]
        [Display(Name = "Telefonnummer")]
        public string? PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta lösenord")]
        [Compare("Password",
            ErrorMessage = "Your password does not match,")]
        public string ConfirmPassword { get; set; }

    }
}
