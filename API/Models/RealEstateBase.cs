using System.ComponentModel.DataAnnotations;

namespace HomeFinder.Models
{
    public class RealEstateBase
    {

        [EnumDataType(typeof(RealEstateTypes))]
        public RealEstateTypes RealEstateType { get; set; }
    }
}