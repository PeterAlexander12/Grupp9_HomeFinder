using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary;

namespace BlazorBroker.Services
{
    public interface IRealEstateService
    {
        Task<IEnumerable<RealEstate>> GetRealEstates();
    }
}
