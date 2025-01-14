﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeFinder.Models
{
    public class EditUserVm
    {

        public string Id { get; set; }

        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }
    
        public EditUserVm()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }
    
    }
}
