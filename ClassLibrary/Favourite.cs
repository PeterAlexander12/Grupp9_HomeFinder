namespace Models
{
    public class Favourite
    {
        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; }
        public string UserId { get; set; }
    }
}
