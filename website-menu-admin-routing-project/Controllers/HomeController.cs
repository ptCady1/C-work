using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Website_SiteMenu_Admin_Routing.Models;

namespace Website_SiteMenu_Admin_Routing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Page2(string num)
        {
            return Content($"Home Page {num}");
        }

        [Route("[controller]/{id}")]
        public IActionResult Page3(int id)
        {
            return Content("Home " + "Page " + id);
        }

        public IActionResult Privacy()
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
