using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinder.Views.Shared
{
    public class SharedController : Controller
    {
        
        public IActionResult Error()
        {
            return View();
        }
    }
}
