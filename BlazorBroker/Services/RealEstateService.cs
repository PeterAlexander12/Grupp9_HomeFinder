using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorBroker.ViewModels;
using ClassLibrary;
using Microsoft.AspNetCore.Components;

namespace BlazorBroker
{
    public class RealEstateService : IRealEstateService
    {
        readonly HttpClient _httpClient;

        public RealEstateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RealEstateViewModel>> GetRealEstates()
        {
            return await _httpClient.GetFromJsonAsync<RealEstateViewModel[]>("/api/RealEstate");
        }

        public async Task<RealEstateViewModel> GetRealEstate(int id)
        {
            return await _httpClient.GetFromJsonAsync<RealEstateViewModel>($"/api/RealEstate/{id}");

        }

        public async Task UpdateRealEstate(PostRealEstateViewModel updatedRealEstate)
        {
            var response = await _httpClient.PutAsJsonAsync("https://localhost:44387/api/RealEstate", updatedRealEstate);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddRealEstate (PostRealEstateViewModel realEstate)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:44387/api/RealEstate", realEstate);
            response.EnsureSuccessStatusCode();
        }

    }
}
