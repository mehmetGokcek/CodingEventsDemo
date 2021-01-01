using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventCategoryViewModel
    {


        [Required(ErrorMessage = "Event Category name is required")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = " must be between 3 and 30 characters long")]
        public string Name { get; set; }

    }
}
