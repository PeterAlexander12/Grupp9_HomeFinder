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
        public string Address { get; set; }
        public string Pictures { get; set; }
        public string Description { get; set; }
        [Display(Name = "Form Of Lease")]
        [Required]
        public string FormOfLease { get; set; }
        [DataType(DataType.Currency)]
        public int Price { get; set; }
        [Display(Name = "Rooms")]
        public int NumberOfRooms { get; set; }
        [Display(Name = "Living Area")]
        public int LivingArea { get; set; }
        [Display(Name = "Construction Year")]
        [DataType(DataType.Date)]
        public DateTime ConstructionYear { get; set; }
        [Display(Name = "Show Date")]
        [DataType(DataType.Date)]
        public DateTime ShowDate { get; set; }
        public List<RegistrationOfInterest> RegistrationsOfInterest{ get; set; }
    }
}
