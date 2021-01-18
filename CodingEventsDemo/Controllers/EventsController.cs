using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace coding_events_practice.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private EventDbContext context;

        public EventsController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            //List<Event> events = new List<Event>(EventData.GetAll());
            List<Event> events = context.Events.Include(e => e.Category).ToList();


            return View(events);
        }

        public IActionResult Add()
        {
            List<EventCategory> categories = context.Categories.ToList();
            AddEventViewModel addEventViewModel = new AddEventViewModel(categories);

            return View(addEventViewModel);
        }



        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {

            if (ModelState.IsValid)
            {
                //Event newEvent = new Event(addEventViewModel.Name, addEventViewModel.Description, addEventViewModel.ContactEmail);
                //EventData.Add(newEvent);
                EventCategory theCategory = context.Categories.Find(addEventViewModel.CategoryId);

                Event newEvent = new Event
                {            

                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Category = theCategory
                };



                context.Events.Add(newEvent);
                context.SaveChanges();

                return Redirect("/Events");
            }


            List<EventCategory> categories = context.Categories.ToList(); //reload category list options to make sure they will appear after the data validation errors

            return View(new AddEventViewModel(categories)); //passing new Model Object with categories list options
           
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


        public IActionResult Detail(int id)
        {
           
                Event theEvent = context.Events
                .Include(e => e.Category)
                .Single(e => e.Id == id);


            List<EventTag> eventTags = context.EventTags
              .Where(et => et.EventId == id)
              .Include(et => et.Tag)
              .ToList();

            EventDetailViewModel viewModel = new EventDetailViewModel(theEvent, eventTags);

            return View(viewModel);
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
