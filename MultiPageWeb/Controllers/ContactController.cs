using Microsoft.AspNetCore.Mvc;
using Multi_PageWebAppCady.Models;

namespace Multi_PageWebAppCady.Controllers
{
    public class ContactController : Controller
    {
        private ContactContext context { get; set; }

        public ContactController(ContactContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Contacts());
        }

        [HttpPost]
        public IActionResult Add(Contacts contact)
        {
            if (ModelState.IsValid)
            {
                context.Contact.Add(contact);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (contact.ContactId == 0) ? "Add" : "Edit";
                return View(contact);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Edit";
            var contact = context.Contact.Find(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Delete(Contacts contact)
        {
            context.Contact.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
