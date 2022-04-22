using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HomeFinder.Models
{
    public class RealEstate
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Adress")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Stad")]
        public string City { get; set; }
        public string CoverPictureURL { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Utgångspris")]
        public int Price { get; set; }

        [Display(Name = "Rooms")]
        public int NumberOfRooms { get; set; }
        [Display(Name = "Living Area")]
        public int LivingArea { get; set; }
        [Display(Name = "Byggår")]
        [DataType(DataType.Date)]
        public DateTime ConstructionYear { get; set; }
        [Display(Name = "Visningsdatum")]
        [DataType(DataType.Date)]
        public DateTime ShowDate { get; set; }


        [Display(Name = "Upplåtelseform")]
        public RealEstateTypes RealEstateType { get; set; }
        public ICollection<RealEstateImage> RealEstateImages { get; set; }
        public IList<Favourite> Favourites { get; set; }


    }
}
