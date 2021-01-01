using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        private EventDbContext context;

        public EventsController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            //List<Event> events = new List<Event>(EventData.GetAll());
            List<Event> events = context.Events.ToList();


            return View(events);
        }

        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }



        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event(addEventViewModel.Name, addEventViewModel.Description, addEventViewModel.ContactEmail);

                //EventData.Add(newEvent);
                context.Events.Add(newEvent);
                context.SaveChanges();

                return Redirect("/Events");
            }

            else 
            {
                return View(addEventViewModel);
            }
        }

        public IActionResult Delete()
        {
            //ViewBag.events = EventData.GetAll();
            ViewBag.events = context.Events.ToList();


            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                //EventData.Remove(eventId);
                Event theEvent = context.Events.Find(eventId);
                context.Events.Remove(theEvent);
            }

            context.SaveChanges();
            return Redirect("/Events");
        }


       /* [Route("Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            ViewBag.eventToEdit = EventData.GetById(eventId);
            return View();
        }

        [HttpPost]
        [Route("Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            EventData.Edit(eventId, name, description);

            return Redirect("/Events");
        }*/
    }
}
