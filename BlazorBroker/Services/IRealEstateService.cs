using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorBroker.ViewModels;
using ClassLibrary;

namespace BlazorBroker
{
    public interface IRealEstateService
    {
        Task<IEnumerable<RealEstateViewModel>> GetRealEstates();
        Task<RealEstateViewModel> GetRealEstate(int id);
        Task UpdateRealEstate(PostRealEstateViewModel updatedRealEstate);
        Task AddRealEstate(PostRealEstateViewModel realEstate);
    }
}
