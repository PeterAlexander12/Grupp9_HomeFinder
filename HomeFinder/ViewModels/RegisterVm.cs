﻿using System.ComponentModel.DataAnnotations;

namespace HomeFinder.Models
{
    public class RegisterVm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }
        [Required]
        [Display(Name = "Förnamn")]
        public string GivenName { get; set; }

        [Required]
        [Display(Name = "Efternamn")]
        public string SurName { get; set; }

        [Phone]
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password  { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta lösenord")]
        [Compare("Password", ErrorMessage = "Lösenorden matchar inte")]
        public string ConfirmPassword { get; set; }

    }
}
