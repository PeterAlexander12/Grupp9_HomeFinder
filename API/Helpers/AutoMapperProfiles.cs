using AutoMapper;
using Models;
using API.ViewModels;

namespace Vehicles_API.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      // Map från -> till
      CreateMap<RealEstateVm, RealEstate>();
      CreateMap<RealEstate, RealEstateVm>();

      //CreateMap<PutManufacturerViewModel, Manufacturer>();
      //CreateMap<Manufacturer, ManufacturerViewModel>()
      //  .ForMember(dest => dest.ManufacturorId, options => options.MapFrom(src => src.Id));
    }
  }
}