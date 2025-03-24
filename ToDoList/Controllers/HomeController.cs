using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ToDoList.Models;

namespace ToDoList.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private TicketContext context;
		public HomeController(TicketContext ctx) => context = ctx;

		public IActionResult Index(string id)
		{
			var filter = new Filter(id);
			ViewBag.Filter = filter;
			ViewBag.Points = context.Points.ToList();
			ViewBag.Statuses = context.Statuses.ToList();

			IQueryable<Ticket> query = context.Tickets
				.Include(t => t.Point).Include(t => t.Status);
			if (filter.HasPoint)
			{
				query = query.Where(t => t.PointId == filter.PointId);
			}
			if (filter.HasStatus)
			{
				query = query.Where(t => t.StatusId == filter.StatusId);
			}
			var tasks = query.OrderBy(t => t.SprintNum).ToList();
			return View(tasks);
		}

		[HttpGet]
		public IActionResult Add() {
		ViewBag.Points = context.Points.ToList() ;
		ViewBag.Statuses = context.Statuses.ToList();
			var task = new Ticket { StatusId = "todo" };
			return View(task);
		}

		[HttpPost]
		public IActionResult Add(Ticket task) 
		{
			if (ModelState.IsValid)
			{
				context.Tickets.Add(task);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Points = context.Points.ToList();
				ViewBag.Statuses = context.Statuses.ToList();
				return View(task);
			}
		}
		[HttpPost]
		public IActionResult Filter(string[] filter)
		{
			string id = string.Join("-", filter);
			return RedirectToAction("Index", new {ID = id});
		}
		[HttpPost]
		public IActionResult MarkDone([FromRoute]string id, Ticket selected)
		{
			selected = context.Tickets.Find(selected.Id)!;
			if(selected == null)
			{
				selected.StatusId = "don";
				context.SaveChanges() ;
			}
			return RedirectToAction("Index", new {ID = id});
		}
		[HttpPost]
		public IActionResult DeleteDone(string id) 
		{
		var toDelete = context.Tickets.Where(t => t.StatusId == "don").ToList();
			foreach (var task in toDelete) 
			{
			context.Tickets.Remove(task);
			}
			context.SaveChanges();
			return RedirectToAction("Index", new { ID = id });
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
