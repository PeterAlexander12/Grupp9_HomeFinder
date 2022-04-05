using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFinder.Models
{
    public class RealEstate
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Adress")]
        public string Address { get; set; }
        public string CoverPictureURL { get; set; }
        public string Description { get; set; }

        public string TestField { get; set; }

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

        public ICollection<RegistrationOfInterest> RegistrationsOfInterest{ get; set; }

        [Display(Name = "Upplåtelseform")]

        public RealEstateTypes RealEstateType { get; set; }
        public ICollection<RealEstateImage> RealEstateImages { get; set; }


    }
}
