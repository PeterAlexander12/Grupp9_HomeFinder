using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeFinder.Data;
using HomeFinder.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace HomeFinder.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly HomeFinderContext _context;
        public RealEstatesController(HomeFinderContext context)
        {
            _context = context;
        }

        // GET: RealEstates
        public async Task<IActionResult> Index(string searchTerm)
        {
            var realEstates = _context.RealEstate.Select(r => r);
;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                realEstates = realEstates.Where(r => r.Address.Contains(searchTerm) || r.Description.Contains(searchTerm));
            }
            return View(await realEstates.ToListAsync());
        }

        // GET: RealEstates/Details/5
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

        // GET: RealEstates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RealEstates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,City,CoverPictureURL,Description,Price,NumberOfRooms,LivingArea,SubsidiaryArea,LotArea,ConstructionYear,ShowDate,RealEstateType, FormOfLease")] RealEstate realEstate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(realEstate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(realEstate);
        }

        [HttpPost]
        public IActionResult Index(List<IFormFile> files)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.
                        var filepath =
       new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "RealEstateImages")).Root + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }

                    }
                }
            }
            return View();
        }

        // GET: RealEstates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realEstate = await _context.RealEstate.FindAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }
            return View(realEstate);
        }

        // POST: RealEstates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,City,CoverPictureURL,Description,Price,NumberOfRooms,LivingArea,SubsidiaryArea,LotArea,ConstructionYear,ShowDate,RealEstateType,FormOfLease")] RealEstate realEstate)
        {
            if (id != realEstate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(realEstate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealEstateExists(realEstate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(realEstate);
        }

        // GET: RealEstates/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: RealEstates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var realEstate = await _context.RealEstate.FindAsync(id);
            _context.RealEstate.Remove(realEstate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RealEstateExists(int id)
        {
            return _context.RealEstate.Any(e => e.Id == id);
        }
    }
}
