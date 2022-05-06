using System;

namespace Models
{
    public class RegistrationOfInterest
    {
        public int Id { get; set; }

        public RealEstate RealEstate { get; set; }

        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}