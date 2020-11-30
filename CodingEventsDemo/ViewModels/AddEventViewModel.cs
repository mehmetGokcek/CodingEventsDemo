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
    }
}
