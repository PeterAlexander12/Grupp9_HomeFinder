using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HomeFinder.Models;

namespace HomeFinder.ViewModels
{
    public class DetailsVm
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string CoverPictureURL { get; set; }
        public string Description { get; set; }

        public string Price { get; set; }

        public string City { get; set; }

        public int NumberOfRooms { get; set; }

        public int LivingArea { get; set; }

        public DateTime ConstructionYear { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public string ShowDate { get; set; }

        public FormOfLease FormOfLease { get; set; }
        public int? SubsidiaryArea { get; set; }
        public int? LotArea { get; set; }


        public string BrokerName { get; set; }

        public RealEstateTypes RealEstateType { get; set; }
        public ICollection<RealEstateImage> RealEstateImages { get; set; }
    }
}