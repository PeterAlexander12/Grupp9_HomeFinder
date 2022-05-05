using HomeFinder.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeFinder.Models;

namespace HomeFinder.Services
{
    public interface IFavouritesService
    {
        Task<IEnumerable<RealEstateVm>> GetFavourites(ApplicationUser user);
    }
}
