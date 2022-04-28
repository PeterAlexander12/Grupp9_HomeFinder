using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class RegistrationOfInterest
    {
        public int Id { get; set; }

        public RealEstate RealEstate { get; set; }

        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}