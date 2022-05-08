using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ViewModels;

namespace API.Data
{
    public interface IRealEstateRepository
    {

        Task UpdateRealEstateAsync(int id, PostRealEstateVm model);
        Task UpdateRealEstateAsync(int id, PatchRealEstateVm model);
        Task<IEnumerable<RealEstateVm>> GetRealEstates();
        Task<RealEstateVm> GetRealEstateAsync(int id);
        Task AddRealEstateAsync(PostRealEstateVm model);
        Task DeleteRealEstateAsync(int id);
        Task<bool> SaveAllAsync();

    }
}
