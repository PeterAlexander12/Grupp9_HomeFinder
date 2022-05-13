using Microsoft.AspNetCore.Mvc;
using HomeFinder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeFinder.Models;
using HomeFinder.ViewModels;
using System.Globalization;

namespace HomeFinder.Controllers
{
    public class GalleryController : Controller
    {
        private readonly HomeFinderContext _context;
        public GalleryController(HomeFinderContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchTerm, string maxSlide, string minSlide, List<int> realEstateType, int minLivingSpace, int maxLivingSpace, string minArea, string maxArea,
            int minRoom, int maxRoom, string minBuildYear, string maxBuildYear, string removeFilter)
        {
            var realEstates = _context.RealEstate.Select(r => r);

            ViewBag.Favourites = _context.Favourites.Select(f => f);
            if (!string.IsNullOrEmpty(removeFilter) && removeFilter.Equals("Rensa filter"))
            {
                return View(await realEstates.ToListAsync());
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                realEstates = realEstates.Where(r => r.Address.Contains(searchTerm) || r.Description.Contains(searchTerm) || r.City.Contains(searchTerm));
            }
            if (!string.IsNullOrEmpty(maxSlide))
            {
                int maxPrice = int.Parse(maxSlide);
                if (maxPrice != 0)
                {
                    realEstates = realEstates.Where(r => r.Price <= maxPrice);
                }
            }
            if (!string.IsNullOrEmpty(minSlide))
            {
                int minPrice = int.Parse(minSlide);

                if (minPrice != 0)
                {
                    realEstates = realEstates.Where(r => r.Price >= minPrice);
                }
            }

            if (realEstateType.Count > 0)
            {

                if (realEstateType.Count == 1)
                {
                    realEstates = realEstates.Where(r => (int)r.RealEstateType == realEstateType.ElementAt(0));
                }

                if (realEstateType.Count == 2)
                {
                    realEstates = realEstates.Where(r => (int)r.RealEstateType == realEstateType.ElementAt(0) || (int)r.RealEstateType == realEstateType.ElementAt(1));
                }

                if (realEstateType.Count == 3)
                {
                    realEstates = realEstates.Where(r => (int)r.RealEstateType == realEstateType.ElementAt(0)
                    || (int)r.RealEstateType == realEstateType.ElementAt(1)
                    || (int)r.RealEstateType == realEstateType.ElementAt(2));
                }
            }

            if (minLivingSpace > 0 || maxLivingSpace > 0)
            {
                if (minLivingSpace > 0 && maxLivingSpace > 0)
                {
                    realEstates = realEstates.Where(r => r.LivingArea > minLivingSpace && r.LivingArea < maxLivingSpace);
                }
                else if (minLivingSpace > 0)
                {
                    realEstates = realEstates.Where(r => r.LivingArea > minLivingSpace);
                }
                else
                {
                    realEstates = realEstates.Where(r => r.LivingArea < maxLivingSpace);
                }
            }


            if (!string.IsNullOrEmpty(minArea) || !string.IsNullOrEmpty(maxArea))
            {
                var min = int.TryParse(minArea, out int resultMin);
                var max = int.TryParse(maxArea, out int resultMax);

                if (resultMin > 0)
                {
                }
            }

            if (minRoom > 0 || maxRoom > 0)
            {
                if (minRoom > 0 && maxRoom > 0)
                {
                    realEstates = realEstates.Where(r => r.NumberOfRooms >= minRoom && r.NumberOfRooms <= maxRoom);
                }
                else if (minRoom > 0)
                {
                    realEstates = realEstates.Where(r => r.NumberOfRooms >= minRoom);
                }
                else
                {
                    realEstates = realEstates.Where(r => r.NumberOfRooms <= maxRoom);
                }
            }

            if (!string.IsNullOrEmpty(minBuildYear) || !string.IsNullOrEmpty(maxBuildYear))
            {
                string dateStringMin = "Jan 1,  " + minBuildYear;
                string dateStringMax = "Jan 1,  " + maxBuildYear;

                var minYear = DateTime.Parse(dateStringMin);
                var maxYear = DateTime.Parse(dateStringMax);

                if (!string.IsNullOrEmpty(minBuildYear))
                {
                    realEstates = realEstates.Where(r => r.ConstructionYear > minYear);
                }
                else if (!string.IsNullOrEmpty(minBuildYear) && !string.IsNullOrEmpty(maxBuildYear))
                {
                    realEstates = realEstates.Where(r => r.ConstructionYear > minYear && r.ConstructionYear < maxYear);
                }
                else
                {
                    realEstates = realEstates.Where(r => r.ConstructionYear < maxYear);
                }
            }

            return View(await realEstates.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realEstate = await _context.RealEstate.Include(r => r.Broker).Include(r => r.RealEstateImages)
                .FirstOrDefaultAsync(m => m.Id == id);

            string brokerDisplayName;

            if (realEstate.Broker == null)
            {
                brokerDisplayName = "Uppgift saknas";
            }
            else
            {
                brokerDisplayName = realEstate.Broker.GivenName += realEstate.Broker.SurName;
            }

            var model = new DetailsVm()
            {
                Address = realEstate.Address,
                City = realEstate.City,
                CoverPictureURL = realEstate.CoverPictureURL,
                RealEstateImages = realEstate.RealEstateImages,
                RealEstateType = realEstate.RealEstateType,
                FormOfLease = realEstate.FormOfLease,
                NumberOfRooms = realEstate.NumberOfRooms,
                LivingArea = realEstate.LivingArea,
                SubsidiaryArea = realEstate.SubsidiaryArea,
                LotArea = realEstate.LotArea,
                ConstructionYear = realEstate.ConstructionYear,
                ShowDate = realEstate.ShowDate.Date.ToShortDateString(),
                BrokerName = brokerDisplayName,
                Description = realEstate.Description,
                Price = realEstate.Price.ToString("c"),
                Id = realEstate.Id
            };
            
            return View(model);

        }
        public async Task<IActionResult> AdvSearch()
        {
            var realEstates = _context.RealEstate.Select(r => r);

            

            return View(await realEstates.ToListAsync());
        }
    }
}