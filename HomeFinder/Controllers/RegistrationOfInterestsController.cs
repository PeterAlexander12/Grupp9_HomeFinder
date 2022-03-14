using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeFinder.Data;
using HomeFinder.Models;

namespace HomeFinder.Controllers
{
    public class RegistrationOfInterestsController : Controller
    {
        private readonly HomeFinderContext _context;

        public RegistrationOfInterestsController(HomeFinderContext context)
        {
            _context = context;
        }

        // GET: RegistrationOfInterests
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistrationOfInterest.ToListAsync());
        }

        // GET: RegistrationOfInterests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationOfInterest = await _context.RegistrationOfInterest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrationOfInterest == null)
            {
                return NotFound();
            }

            return View(registrationOfInterest);
        }

        // GET: RegistrationOfInterests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistrationOfInterests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date")] RegistrationOfInterest registrationOfInterest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrationOfInterest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registrationOfInterest);
        }

        // GET: RegistrationOfInterests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationOfInterest = await _context.RegistrationOfInterest.FindAsync(id);
            if (registrationOfInterest == null)
            {
                return NotFound();
            }
            return View(registrationOfInterest);
        }

        // POST: RegistrationOfInterests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date")] RegistrationOfInterest registrationOfInterest)
        {
            if (id != registrationOfInterest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrationOfInterest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationOfInterestExists(registrationOfInterest.Id))
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
            return View(registrationOfInterest);
        }

        // GET: RegistrationOfInterests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationOfInterest = await _context.RegistrationOfInterest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrationOfInterest == null)
            {
                return NotFound();
            }

            return View(registrationOfInterest);
        }

        // POST: RegistrationOfInterests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registrationOfInterest = await _context.RegistrationOfInterest.FindAsync(id);
            _context.RegistrationOfInterest.Remove(registrationOfInterest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationOfInterestExists(int id)
        {
            return _context.RegistrationOfInterest.Any(e => e.Id == id);
        }
    }
}
