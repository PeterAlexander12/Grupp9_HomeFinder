using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ViewModels;

namespace API.Repositories
{
    public interface IRealEstateRepository
    {
        Task<IEnumerable<RealEstateVm>> GetRealEstates();
        Task<RealEstateVm> GetRealEstate(int id);
        Task<RealEstateVm> AddRealEstate(RealEstateVm realEstate);
        Task UpdateRealEstateAsync(RealEstateVm model);
        Task DeleteRealEstateAsync(int id);
        Task<IEnumerable<RealEstateVm>> GetUserFavourites(string userId);
        Task<RealEstateVm> GetRealEstateForBroker(int id);


        // ADD SAVEALLASYNC METHOD




    }
}
