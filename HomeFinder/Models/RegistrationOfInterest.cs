using System;

namespace HomeFinder.Models
{
    public class RegistrationOfInterest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}
