using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class ApplicationUser : IdentityUser
    {
        public string GivenName { get; set; }
        public string SurName { get; set; }
        //public IList<FavouriteVm> Favourites { get; set; }
    }
}
