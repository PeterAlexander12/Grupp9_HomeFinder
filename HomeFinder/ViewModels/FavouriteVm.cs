using HomeFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.ViewModels
{
    public class FavouriteVm
    {
        public int RealEstateId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
