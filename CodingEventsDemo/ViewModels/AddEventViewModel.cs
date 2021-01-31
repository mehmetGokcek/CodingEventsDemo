using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventViewModel
    {

        [Required(ErrorMessage = "Event name is required")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = " must be between 3 and 12 characters long")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Desciption is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Sorry, but the description is too short. Description must be at least 6 characters long.")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Compare("ContactEmail")]
        public string ConfirmEmail{ get; set; }


        public EventAddress eventAddress { get; set; }


        //To see why "int?" got to https://csharp-video-tutorials.blogspot.com/2019/04/select-list-validation-in-aspnet-core.html
        [Required(ErrorMessage ="Category is required")]
        public int? CategoryId { get; set; }
       
        public List<SelectListItem> Categories { get; set; }

        public AddEventViewModel(List<EventCategory> categories, EventAddress newEventAddress)
        {
            Categories = new List<SelectListItem>();

            foreach(var category in categories) 
            { Categories.Add(
                new SelectListItem
                { 
                  Value =  category.Id.ToString(),
                  Text = category.Name
                }
                );; 
            }

            EventAddress eventAddress = newEventAddress;
        }

        public AddEventViewModel() { }
    }
}
