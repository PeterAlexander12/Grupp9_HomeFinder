using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HomeFinder.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace HomeFinder.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public IList<FavouriteVm> Favourites { get; set; }
    }
}
