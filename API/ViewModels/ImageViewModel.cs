using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace API.ViewModels
{
    public class ImageViewModel
    {
        public List<IFormFile> Images { get; set; }
        public RealEstateVm RealEstate { get; set; }
    }
}
