using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HomeFinder.Models;
using HomeFinder.ViewModels;

namespace HomeFinder.Services
{
    public class FavouritesService : IFavouritesService
    {
        readonly HttpClient _httpClient;

        public FavouritesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RealEstateVm>> GetFavourites(ApplicationUser user)
        {
            var userId = user.Id;
            return await _httpClient.GetFromJsonAsync<RealEstateVm[]>($"/api/Favourites/{userId}");

        }

        
    }
}
