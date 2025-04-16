using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ToDoList.Models;
using ToDoList.Repository;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private TicketContext context;
        private readonly IRepository<Ticket> tickRepo;
        private readonly IRepository<Point> pointRepo;
        private readonly IRepository<Status> statRepo;
        public HomeController(IRepository<Ticket> ticketRepo,IRepository<Point> pointRepo, IRepository<Status> statusRepo, TicketContext  ctx)
        {
            this.tickRepo = ticketRepo;
            this.pointRepo = pointRepo;
            this.statRepo = statusRepo;
            this.context = ctx;
        }
       // public HomeController(TicketContext ctx) => context = ctx;

        public IActionResult Index(string id)
        {
            var filter = new Filter(id);
            ViewBag.Filter = filter;
            ViewBag.Points = pointRepo.GetAll();
            ViewBag.Statuses = statRepo.GetAll();

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
        public IActionResult Add()
        {
            ViewBag.Points = pointRepo.GetAll();
            ViewBag.Statuses = statRepo.GetAll();
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
                ViewBag.Points = pointRepo.GetAll();
                ViewBag.Statuses = statRepo.GetAll();
                return View(task);
            }
        }
        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join("-", filter);
            return RedirectToAction("Index", new { ID = id });
        }
        [HttpPost]
        public IActionResult MarkDone([FromRoute] int id, Ticket selected)
        {
            selected = tickRepo.Get(selected.Id)!;
            if (selected == null)
            {
                selected.StatusId = "don";
                tickRepo.Save();
            }
            return RedirectToAction("Index", new { ID = id });
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
