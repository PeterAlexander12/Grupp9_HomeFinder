namespace API.Models
{
    public class Favourite
    {
        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
