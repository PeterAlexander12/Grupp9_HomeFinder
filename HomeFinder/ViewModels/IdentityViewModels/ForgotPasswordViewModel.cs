using System.ComponentModel.DataAnnotations;

namespace HomeFinder.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
