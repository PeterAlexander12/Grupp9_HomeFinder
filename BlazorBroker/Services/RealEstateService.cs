using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ClassLibrary;

namespace BlazorBroker.Services
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

    }
}
