using Assignments.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Assignments.Controllers
{
    public class CountryController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CountryController(CountryContext ctx) => context = ctx;

        public CountryContext context { get; set; }

        public ViewResult TheGames(CountryViewModel model)
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
            var country = context.Countries
                //Country = context.Countries
                .Include(c => c.Games)
                .Include(c => c.SportType)
                .FirstOrDefault(c => c.countryID == id) ?? new Country();
            return View(country);
        }
            //ActiveConf = TempData.Peek("ActiveConf").ToString(),
            // ActiveDiv = TempData.Peek("ActiveDiv").ToString()

    }
}
