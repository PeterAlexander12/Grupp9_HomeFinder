using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ClassLibrary;
using Microsoft.AspNetCore.Components;

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

        public async Task<RealEstate> UpdateRealEstate(RealEstate updatedRealEstate)
        {
            //return await _httpClient.PutJsonAsync<RealEstate>("api/RealEstate", updatedRealEstate);
            //return _httpClient.PutAsync<RealEstate>("api/RealEstate", updatedRealEstate);
            return null;

        }



    }
}
