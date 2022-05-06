using System.Threading.Tasks;
using BlazorBroker.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazorBroker.Pages
{
    public class EditRealEstateBase : ComponentBase
    {
        public PostRealEstateViewModel RealEstate { get; set; } = new();



        [Inject]
        public IRealEstateService RealEstateService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            var realEstateTemp = await RealEstateService.GetRealEstate(int.Parse(Id));

            RealEstate.Address = realEstateTemp.Address;
            RealEstate.City = realEstateTemp.City;
            RealEstate.ConstructionYear = realEstateTemp.ConstructionYear;
            RealEstate.ShowDate = realEstateTemp.ShowDate;
            RealEstate.LivingArea = realEstateTemp.LivingArea;
            RealEstate.LotArea = realEstateTemp.LotArea;
            RealEstate.CoverPictureURL = realEstateTemp.CoverPictureURL;
            RealEstate.Description = realEstateTemp.Description;
            RealEstate.NumberOfRooms = realEstateTemp.NumberOfRooms;
            RealEstate.Price = realEstateTemp.Price;
            RealEstate.SubsidiaryArea = realEstateTemp.SubsidiaryArea;
        }

        public async Task OnValidSubmit()
        {
            await RealEstateService.UpdateRealEstate(RealEstate);
        }


    }


}