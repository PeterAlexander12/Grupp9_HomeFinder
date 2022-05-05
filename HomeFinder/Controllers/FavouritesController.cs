using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeFinder.Models;
using HomeFinder.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HomeFinder.Controllers
{
    public class FavouritesController : Controller
    {
        readonly IFavouritesService _service;
        readonly UserManager<ApplicationUser> _userManager;

        public FavouritesController(IFavouritesService service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: Favourites
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new Exception($"Kunde inte hitta användare");
            }

            var favourites = await _service.GetFavourites(user);
            return View();
        }

        // GET: Favourites/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var favourite = await _service.Favourites
        //        .Include(f => f.RealEstate)
        //        .Include(f => f.User)
        //        .FirstOrDefaultAsync(m => m.UserId == id);
        //    if (favourite == null)
        //    {
        //        return NotFound();
        //    }
        //    /
        //    return View(favourite);
        //}

        // GET: Favourites/Create

        //    public IActionResult Create()
        //    {
        //        ViewData["RealEstateId"] = new SelectList(_service.RealEstate, "Id", "Address");
        //        ViewData["UserId"] = new SelectList(_service.Users, "Id", "Id");
        //        return View();
        //    }

        //    // POST: Favourites/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("RealEstateId,UserId")] Favourite favourite)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _service.Add(favourite);
        //            await _service.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["RealEstateId"] = new SelectList(_service.RealEstate, "Id", "Address", favourite.RealEstateId);
        //        ViewData["UserId"] = new SelectList(_service.Users, "Id", "Id", favourite.UserId);
        //        return View(favourite);
        //    }

        //    // Kontrollera om användaren har realEstateId bland sina favoriter
        //    // Ja => RemoveFromFavourites()
        //    // Nej=> AddToFavourites()
        //    [HttpPost]
        //    public async Task<IActionResult> HandleFavourite(int realEstateId)
        //    {
        //        var user = await _service.Users.Include(u => u.Favourites).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
        //        bool shouldAddToFavourites = true;
        //        foreach (var item in user.Favourites)
        //        {
        //            if (item.RealEstateId == realEstateId)
        //            {
        //                shouldAddToFavourites = false;
        //                break;
        //            }
        //        }

        //        if (shouldAddToFavourites)
        //        {
        //           return await AddToFavourites(user.Id, realEstateId);
        //        }

        //        else
        //        {
        //            return await RemoveFromFavourites(user.Id, realEstateId);
        //        }
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> AddToFavourites(string userId, int realEstateId)
        //    {   
        //        var favourite = new Favourite();
        //        favourite.RealEstateId = realEstateId;
        //        favourite.UserId = userId;

        //        _service.Add(favourite);
        //        await _service.SaveChangesAsync();
        //        return RedirectToAction("Index", "Gallery");
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> RemoveFromFavourites(string userId, int realEstateId)
        //    {
        //        var favourite = await _service.Favourites
        //           .Include(f => f.RealEstate)
        //           .Include(f => f.User)
        //           .Where(m => m.RealEstateId == realEstateId)
        //           .FirstOrDefaultAsync(m => m.UserId == userId);

        //        _service.Favourites.Remove(favourite);
        //        await _service.SaveChangesAsync();
        //        return RedirectToAction("Index", "Gallery");
        //    }

        //    // GET: Favourites/Edit/5
        //    public async Task<IActionResult> Edit(string id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var favourite = await _service.Favourites.FindAsync(id);
        //        if (favourite == null)
        //        {
        //            return NotFound();
        //        }
        //        ViewData["RealEstateId"] = new SelectList(_service.RealEstate, "Id", "Address", favourite.RealEstateId);
        //        ViewData["UserId"] = new SelectList(_service.Users, "Id", "Id", favourite.UserId);
        //        return View(favourite);
        //    }

        //    // POST: Favourites/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(string id, [Bind("RealEstateId,UserId")] Favourite favourite)
        //    {
        //        if (id != favourite.UserId)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _service.Update(favourite);
        //                await _service.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!FavouriteExists(favourite.UserId))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["RealEstateId"] = new SelectList(_service.RealEstate, "Id", "Address", favourite.RealEstateId);
        //        ViewData["UserId"] = new SelectList(_service.Users, "Id", "Id", favourite.UserId);
        //        return View(favourite);
        //    }

        //    // GET: Favourites/Delete/5
        //    public async Task<IActionResult> Delete(Favourite fav)
        //    {
        //        if (fav.UserId == null)
        //        {
        //            return NotFound();
        //        }

        //        var favourite = await _service.Favourites
        //            .Include(f => f.RealEstate)
        //            .Include(f => f.User)
        //            .Where(m => m.RealEstateId == fav.RealEstateId)
        //            .FirstOrDefaultAsync(m => m.UserId == fav.UserId);
        //        if (favourite == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(favourite);
        //    }

        //    // POST: Favourites/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(Favourite fav)
        //    {
        //        var favourite = await _service.Favourites
        //           .Include(f => f.RealEstate)
        //           .Include(f => f.User)
        //           .Where(m => m.RealEstateId == fav.RealEstateId)
        //           .FirstOrDefaultAsync(m => m.UserId == fav.UserId);

        //        _service.Favourites.Remove(favourite);
        //        await _service.SaveChangesAsync();
        //        return RedirectToAction("MyFavourites", "Account");
        //    }

        //    private bool FavouriteExists(string id)
        //    {
        //        return _service.Favourites.Any(e => e.UserId == id);
        //    }
    }
}

