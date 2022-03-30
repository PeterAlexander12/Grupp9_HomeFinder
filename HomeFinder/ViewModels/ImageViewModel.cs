using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeFinder.Models
{
    public class ImageViewModel
    {
        public List<IFormFile> Images { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}
