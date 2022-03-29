using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeFinder.Data;
using HomeFinder.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace HomeFinder.Controllers
{
    public class RealEstateImagesController : Controller
    {
        private readonly HomeFinderContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;



        public RealEstateImagesController(HomeFinderContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;

        }

        // GET: RealEstateImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.RealEstateImages.ToListAsync());
        }

        // GET: RealEstateImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realEstateImage = await _context.RealEstateImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realEstateImage == null)
            {
                return NotFound();
            }

            return View(realEstateImage);
        }

        // GET: RealEstateImages/Create
        public IActionResult Create()
        {
            ProImages vm = new ProImages();
            ViewBag.realEstates = new SelectList(_context.RealEstate.ToList(), "Id", "Address");
            return View(vm);
        }

        // POST: RealEstateImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProImages vm)
        {

            try
            {
                foreach (var item in vm.Images)
                {
                    string stringFileName = UploadFile(item);
                    var realEstateImage = new RealEstateImage
                    {
                        ImageURL = stringFileName,
                        RealEstate = _context.RealEstate.First(r => r.Id == vm.RealEstate.Id)
                    };
                    _context.Add(realEstateImage);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index");
        }

        private string UploadFile(IFormFile file)
        {
            string fileName = null;
            if (file != null)
            {
                string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        // GET: RealEstateImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realEstateImage = await _context.RealEstateImages.FindAsync(id);
            if (realEstateImage == null)
            {
                return NotFound();
            }
            return View(realEstateImage);
        }

        // POST: RealEstateImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageURL")] RealEstateImage realEstateImage)
        {
            if (id != realEstateImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(realEstateImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealEstateImageExists(realEstateImage.Id))
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
            return View(realEstateImage);
        }

        // GET: RealEstateImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realEstateImage = await _context.RealEstateImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realEstateImage == null)
            {
                return NotFound();
            }

            return View(realEstateImage);
        }

        // POST: RealEstateImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var realEstateImage = await _context.RealEstateImages.FindAsync(id);
            _context.RealEstateImages.Remove(realEstateImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RealEstateImageExists(int id)
        {
            return _context.RealEstateImages.Any(e => e.Id == id);
        }
    }
}
