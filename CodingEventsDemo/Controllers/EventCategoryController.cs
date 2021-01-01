using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Controllers
{
    public class EventCategoryController: Controller
    { 

        private EventDbContext context;

        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }


        public IActionResult Index()
        {
            List<EventCategory> eventsCategory = context.EventsCategory.ToList();

            return View(eventsCategory);
        }

        public IActionResult Create() {

            return View(new AddEventCategoryViewModel());
        }

        [HttpPost("/EventCategory/Add")]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategoryViewModel) 
        {
            if (ModelState.IsValid)
            {
                EventCategory newEventCategory = new EventCategory(addEventCategoryViewModel.Name);

                context.EventsCategory.Add(newEventCategory);
                context.SaveChanges();

                return Redirect("/EventCategory");
            }

            else
            {
                return View("Create", addEventCategoryViewModel);
            }
        }

    }
}
