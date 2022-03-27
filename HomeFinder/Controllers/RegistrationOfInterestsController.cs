using System;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using HomeFinder.Data;
using HomeFinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult Index(int RealEstateId)
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
        public async Task<IActionResult> Create(RegistrationOfInterest roi)
        {

            if (ModelState.IsValid)
            {   
                roi.Date = DateTime.Now;
                _context.Add(roi);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Gallery");

            }

            return View();
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
