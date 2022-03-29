using Microsoft.AspNetCore.Mvc;
using HomeFinder.Data; 
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
        public async Task<IActionResult> Index(string searchTerm, string maxSlide, string minSlide)
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

            return View(await realEstates.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realEstate = await _context.RealEstate
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
