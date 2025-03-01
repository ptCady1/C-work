using DataTransfer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataTransfer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(CountryContext ctx) => context = ctx;

        public CountryContext context { get; set; }

        public ViewResult Index(CountryViewModel model)
        {

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
