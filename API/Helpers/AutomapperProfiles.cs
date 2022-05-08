using API.Models;
using API.ViewModels;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Map från -> till
            CreateMap<PostRealEstateVm, RealEstate>();
            CreateMap<RealEstate, RealEstateVm>();
            CreateMap<PutRealEstateVm, RealEstate>();
            
        }
    }
}
