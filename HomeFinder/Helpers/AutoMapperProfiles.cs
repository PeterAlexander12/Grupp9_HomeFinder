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
      CreateMap<PostRealEstateVm, RealEstate>();
      CreateMap<RealEstate, RealEstateVm>()
        .ForMember(dest => dest.VehicleId, options => options.MapFrom(src => src.Id))
        .ForMember(dest => dest.VehicleName, options => options.MapFrom(src => string.Concat(src.Manufacturer.Name, " ", src.Model)));

      CreateMap<PostManufacturerViewModel, Manufacturer>();
      CreateMap<PutManufacturerViewModel, Manufacturer>();
      CreateMap<Manufacturer, ManufacturerViewModel>()
        .ForMember(dest => dest.ManufacturorId, options => options.MapFrom(src => src.Id));
    }
  }
}