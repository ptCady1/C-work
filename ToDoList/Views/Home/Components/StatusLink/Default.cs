using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Views.Home.Components.StatusLink
{
    public class Default : ViewComponent
    {
        public IViewComponentResult Invoke(string id, string name)
        {
            Status status = new Status
            {
                StatusId = id,
                Name = name
            };
            return View(status);
        }
    }
}
