using System.Collections.Generic;
using System.Threading.Tasks;
using HomeFinder.ViewModels;

namespace HomeFinder.Services
{
    public interface IRealEstateService
    {
        Task<IEnumerable<RealEstateVm>> GetRealEstates();
        Task<RealEstateVm> GetRealEstate(int id);
        Task UpdateRealEstate(RealEstateVm updatedRealEstate);
        Task AddRealEstate(RealEstateVm realEstate);
    }
}
