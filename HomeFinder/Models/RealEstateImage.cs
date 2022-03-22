using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeFinder.Models
{
    public class RealEstateImage
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}
