﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeFinder.Models
{
    public class RealEstate
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Pictures { get; set; }
        public string Description { get; set; }
        public string FormOfLease { get; set; }
        public decimal Price { get; set; }
        public int NumberOfRooms { get; set; }
        public int LivingArea { get; set; }
        public DateTime ConstructionYear { get; set; }
        public DateTime ShowDate { get; set; }
        public List<RegistrationOfInterest> RegistrationsOfInterest{ get; set; }

        
        public RealEstateTypes RealEstateType { get; set; }

    }
}
