using Microsoft.AspNetCore.Mvc;
using Assignments.Models;

namespace Assignments.Controllers
{
    public class StudentController : Controller
    {
        private StudentContext context { get; set; }

        public StudentController(StudentContext ctx) => context = ctx;
        [HttpGet]
        public IActionResult StudentGrades(int param)
        {
            ViewBag.level = param;
            var students = context.Students.OrderBy(c => c.firstName).ToList();
            return View(students);
        }
    }
}
