using BlazorBroker.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBroker.Pages
{
    public class RealEstateListBase : ComponentBase
    {
        [Inject]
        public IRealEstateService RealEstateService { get; set; }

        public IEnumerable<RealEstateViewModel> RealEstates { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //var hus = (await RealEstateService.GetRealEstates()).ToList();
            RealEstates = (await RealEstateService.GetRealEstates()).ToList();
        }

        //private void LoadEmployees()
        //{
        //    RealEstate r1 = new RealEstate() { Id = 1, Address = "abcd",  };
        //    RealEstate r2 = new RealEstate() { Id = 1, Address = "abcd",  };

        //    RealEstates = new List<RealEstate> { r1, r2 };
        //}
    }
}
