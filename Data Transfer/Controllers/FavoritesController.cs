using DataTransfer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace DataTransfer.Controllers
{
	public class FavoritesController : Controller
	{
		private CountryContext context;
		public FavoritesController(CountryContext cxt) => context = cxt;

		[HttpGet]
		public IActionResult Index()
		{
			var session = new CountrySession(HttpContext.Session);
			var model = new CountryViewModel
			{
				ActiveConf = session.GetActiveConf(),
				ActiveDiv = session.GetActiveDiv(),
				Countries = session.GetMyCountries(),
			};
			return View(model);
		}
		[HttpPost]
		public RedirectToActionResult Add(Country country)
		{
		country = context.Countries
			.Include(c => c.Games)
			.Include(c => c.SportType)
			.Where(c => c.countryID == country.countryID)
			.FirstOrDefault() ?? new Country();

			var session = new CountrySession(HttpContext.Session);
			var countries = session.GetMyCountries();
			countries.Add(country);
			session.SetMyCountries(countries);

			TempData["message"] = $"{country.countryName} added to your favorites";
			return RedirectToAction("Index", "Home",
				new
				{
					ActiveConf = session.GetActiveConf(),
					ActiveDiv = session.GetActiveDiv(),
				});
		}
		[HttpPost]
		public RedirectToActionResult Delete()
		{
			var session = new CountrySession(HttpContext.Session);
			session.RemoveCountries();

			TempData["message"] = $"Favorite countries cleared";
			return RedirectToAction("Index", "Home",
				new
				{
					ActiveConf = session.GetActiveConf(),
					ActiveDiv = session.GetActiveDiv(),
				});
		}
	}
}
