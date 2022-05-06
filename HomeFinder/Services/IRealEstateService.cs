using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace HomeFinder.Services
{
    public interface IRealEstateService
    {
        Task<IEnumerable<RealEstate>> GetRealEstates();
        Task<IEnumerable<RealEstate>> GetRealEstates(string searchTerm);
        Task<RealEstate> GetRealEstate(int id);
        Task UpdateRealEstate(RealEstate updatedRealEstate);
        Task AddRealEstate(RealEstate realEstate);
        

    }
}
