using Assignments.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
