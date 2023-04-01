using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NewsWise.Models;

namespace NewsWise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Definition()
        {
            return View();
        }
        public IActionResult SearchResult()
        {
            return View();
        }
        public IActionResult Existence()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SpotTip()
        {
            return View();
        }
        public IActionResult Education()
        {
            return View();
        }

        public IActionResult NewsSpotter() 
        {
            return View();
        }
        public IActionResult Quiz()
        {
            return View();
        }
        
        public IActionResult About()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}