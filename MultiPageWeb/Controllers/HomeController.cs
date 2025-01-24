using Microsoft.AspNetCore.Mvc;
using Multi_PageWebAppCady.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Multi_PageWebAppCady.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ContactContext ctx) => context = ctx;
        public ContactContext context { get; set; }

        public IActionResult Index()
        {
            var contacts = context.Contact.OrderBy(c => c.Name).ToList();
            return View(contacts);
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
