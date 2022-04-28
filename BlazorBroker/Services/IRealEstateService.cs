using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary;

namespace BlazorBroker
{
    public interface IRealEstateService
    {
        Task<IEnumerable<RealEstate>> GetRealEstates();
        Task<RealEstate> GetRealEstate(int id);
        Task UpdateRealEstate(RealEstate updatedRealEstate);


        Task AddRealEstate(RealEstate realEstate);
    }
}
