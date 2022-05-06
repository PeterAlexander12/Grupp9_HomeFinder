namespace API.Models
{
    public class RealEstateImage
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}
