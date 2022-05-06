using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class RealEstateBase
    {

        [EnumDataType(typeof(RealEstateTypes))]
        public RealEstateTypes RealEstateType { get; set; }
    }
}