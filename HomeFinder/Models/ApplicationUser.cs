using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HomeFinder.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public IList<Favourite> Favourites { get; set; }
    }
}
