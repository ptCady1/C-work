using DataTransfer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataTransfer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(CountryContext ctx) => context = ctx;

        private CountryContext context;

        public ViewResult Index(CountryViewModel model)
        {
            var session = new CountrySession(HttpContext.Session);
            session.SetActiveConf(model.ActiveConf);
            session.SetActiveDiv(model.ActiveDiv);

            model.Game = context.Game.ToList();
            model.SportsTypes = context.SportsTypes.ToList();

            IQueryable<Country> query = context.Countries.OrderBy(c => c.countryName);
            if (model.ActiveConf != "all")
                query = query.Where(
                    c => c.Games.GamesID.ToLower() == model.ActiveConf.ToLower());
            if (model.ActiveDiv != "all")
                query = query.Where(
                    c => c.SportType.SportTypeID.ToLower() == model.ActiveDiv.ToLower());

            model.Countries = query.ToList();
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Details(CountryViewModel model)
        {
            // Utility.LogCountryClick(model.Country.countryID);
            TempData["ActiveConf"] = model.ActiveConf;
            TempData["ActiveDiv"] = model.ActiveDiv;
            return RedirectToAction("Details", new { ID = model.Country.countryID });

        }
        [HttpGet]
        public ViewResult Details(string id)
        {
            var session = new CountrySession(HttpContext.Session);
            var model = new CountryViewModel
            {
             Country = context.Countries
            .Include(c => c.Games)
            .Include(c => c.SportType)
            .FirstOrDefault(c => c.countryID == id) ?? new Country(),
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv()
            };
            return View(model);
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
