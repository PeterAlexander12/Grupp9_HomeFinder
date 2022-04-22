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
        void DeleteRealEstate(int id);




    }
}
