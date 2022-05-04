using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HomeFinder.ViewModels;

namespace HomeFinder.Services
{
    public class RealEstateService : IRealEstateService
    {
        readonly HttpClient _httpClient;

        public RealEstateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RealEstateVm>> GetRealEstates()
        {
            return await _httpClient.GetFromJsonAsync<RealEstateVm[]>("/api/RealEstate");
        }

        public async Task<RealEstateVm> GetRealEstate(int id)
        {
            return await _httpClient.GetFromJsonAsync<RealEstateVm>($"/api/RealEstate/{id}");

        }

        public async Task UpdateRealEstate(RealEstateVm updatedRealEstate)
        {
            var response = await _httpClient.PutAsJsonAsync("https://localhost:44387/api/RealEstate", updatedRealEstate);
            response.EnsureSuccessStatusCode();
        }
        
        public async Task AddRealEstate(RealEstateVm realEstate)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:44387/api/RealEstate", realEstate);
            response.EnsureSuccessStatusCode();
        }
    }
}
