using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ClassLibrary;

namespace BlazorBroker
{
    public class RealEstateService : IRealEstateService
    {
        readonly HttpClient _httpClient;

        public RealEstateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RealEstate>> GetRealEstates()
        {
            return await _httpClient.GetFromJsonAsync<RealEstate[]>("/api/RealEstate");
        }

        public async Task<RealEstate> GetRealEstate(int id)
        {
            return await _httpClient.GetFromJsonAsync<RealEstate>($"/api/RealEstate/{id}");

        }

        public async Task AddRealEstate (RealEstate realEstate)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:44387/api/RealEstate", realEstate);
            response.EnsureSuccessStatusCode();
        }

    }
}
