using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeFinder.Models
{
    public class ProImages
    {
        public List<IFormFile> Images { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}
