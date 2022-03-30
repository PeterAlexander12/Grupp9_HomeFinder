using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Threading.Tasks;
using HomeFinder.Data;
using HomeFinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeFinder.Controllers
{
    public class RegistrationOfInterestsController : Controller
    {
        readonly HomeFinderContext _context;

        public RegistrationOfInterestsController(HomeFinderContext context)
        {
            _context = context;
        }

        // GET: RegistrationOfInterestsController
        public ActionResult Index()
        {

            return View();
        }

        // GET: RegistrationOfInterestsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrationOfInterestsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrationOfInterestsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string message, int? id)
        {
            var realEstate = _context.RealEstate.FirstOrDefault(r => r.Id == id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (!ModelState.IsValid) return View();
            var roi = new RegistrationOfInterest
            {
                Date = DateTime.Now,
                RealEstate = realEstate,
                Message = message,
                User = user
            };
            _context.Add(roi);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Gallery");


        }


        // GET: RegistrationOfInterestsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrationOfInterestsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrationOfInterestsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrationOfInterestsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
