using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeFinder.Models;

namespace API.Data
{
    public interface IRealEstateRepository
    {
        Task<IEnumerable<RealEstate>> GetRealEstates();
        Task<RealEstate> GetRealEstate(int id);
        Task<RealEstate> AddRealEstate(RealEstate realEstate);
        Task<RealEstate> UpdateRealEstate(RealEstate realEstate);
        Task<RealEstate> DeleteRealEstate(int id);
        Task<IEnumerable<RealEstate>> GetUserFavourites(string userId);
        Task<RealEstate> GetRealEstateForBroker(int id);


        // ADD SAVEALLASYNC METHOD




    }
}
