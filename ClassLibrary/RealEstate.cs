using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ClassLibrary
{
    public class RealEstate
    {
        //public int Id;
        //public string Address;

        public int Id { get; set; }

        [Required]
        [Display(Name = "Adress")]
        public string Address { get; set; }
        [Display(Name = "Ort")]
        public string City { get; set; }
        [Display(Name = "URL för omslagsbild")]
        public string CoverPictureURL { get; set; }
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Utgångspris")]
        public int Price { get; set; }
        [Display(Name = "Antal rum")]
        public int NumberOfRooms { get; set; }
        [Display(Name = "Boarea")]
        public int LivingArea { get; set; }
        [Display(Name = "Biarea")]
        public int? SubsidiaryArea { get; set; }
        [Display(Name = "Tomtarea")]
        public int? LotArea { get; set; }
        [Display(Name = "Byggår")]
        [DataType(DataType.Date)]
        public DateTime ConstructionYear { get; set; }
        [Display(Name = "Visningstid")]
        public DateTime ShowDate { get; set; }

        //public ApplicationUser Broker { get; set; }
        //[Display(Name = "Bostadstyp")]
        //public RealEstateTypes RealEstateType { get; set; }
        //[Display(Name = "Upplåtelseform")]
        //public FormOfLease FormOfLease { get; set; }
        //public ICollection<RealEstateImage> RealEstateImages { get; set; }
        //public IList<Favourite> Favourites { get; set; }
        //public List<RegistrationOfInterest> RegistrationsOfInterest { get; set; }
    }
}
