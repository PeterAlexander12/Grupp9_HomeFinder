using Microsoft.AspNetCore.Mvc;
using HomeFinder.Data;
using HomeFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HomeFinder.Controllers
{
    public class GalleryController : Controller
    {
        private readonly HomeFinderContext _context; 
        public GalleryController(HomeFinderContext context)
        {
            _context = context; 
        }
        
        public async Task<IActionResult> Index(string searchTerm, string maxSlide, string minSlide, string minLivingSlide, string RealEstateType, string NumberOfRooms, string Ålderpåhus)
        {
            var realEstates = _context.RealEstate.Select(r => r);
            
            if (!string.IsNullOrEmpty(searchTerm))
            {
                realEstates = realEstates.Where(r => r.Address.Contains(searchTerm) || r.Description.Contains(searchTerm));
            }
            if (!string.IsNullOrEmpty(maxSlide))
            {
                int maxPrice = int.Parse(maxSlide);
                realEstates = realEstates.Where(r => r.Price <= maxPrice);
            }
            if (!string.IsNullOrEmpty(minSlide))
            {
                int minPrice = int.Parse(minSlide);
                realEstates = realEstates.Where(r => r.Price >= minPrice);
            }
            if (!string.IsNullOrEmpty(minLivingSlide))
            {
                int minLivingArea = int.Parse(minLivingSlide);
                realEstates = realEstates.Where(r => r.LivingArea >= minLivingArea);
            }
            if (!string.IsNullOrEmpty(NumberOfRooms))
            {
                int numbOfRooms = int.Parse(NumberOfRooms);
                realEstates = realEstates.Where(r => r.NumberOfRooms >= numbOfRooms);
            }

            if (!string.IsNullOrEmpty(RealEstateType))
            {
                RealEstateTypes test = (RealEstateTypes)Enum.Parse(typeof(RealEstateTypes), RealEstateType);
                realEstates = realEstates.Where(r => r.RealEstateType.Equals(test));
            }

            if (!string.IsNullOrEmpty(Ålderpåhus))
            {
                if(Ålderpåhus != "Ingen")
                {
                    int _Ålderpåhus = int.Parse(Ålderpåhus);

                    int Condition = DateTime.Now.Year - _Ålderpåhus;
                    realEstates = realEstates.Where(r => r.ConstructionYear.Year >= Condition);
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

            var realEstate = await _context.RealEstate.Include(x => x.RealEstateImages)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realEstate == null)
            {
                return NotFound();
            }

            return View(realEstate);
        }
        public async Task<IActionResult> AdvSearch()
        {
            return View(await _context.RealEstate.ToListAsync());
        }
    }
}
