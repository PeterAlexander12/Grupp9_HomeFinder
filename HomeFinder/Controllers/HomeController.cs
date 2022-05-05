using HomeFinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HomeFinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeFinderContext _context;

        public HomeController(ILogger<HomeController> logger, HomeFinderContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var slides = new List<RealEstate>();

            foreach (var realEstate in _context.RealEstate)
            {
                slides.Add(realEstate);
            }

            return View(slides);
        }

        public IActionResult Terms()
        {
            return View();
        }

        public IActionResult Cookies()
        {
            return View();
        }

        public IActionResult UserTerms()
        {
            return View();
        }

        public IActionResult EndorsementOnHomefinder()
        {
            return View();
        }

        public IActionResult SellWithUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVm { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
