using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
        public class Event
        {

            
            public string Name { get; set; }
            public string Description { get; set; }
            public string ContactEmail { get; set; }
            public int Id { get; }
            static private int nextId = 1;

            public Event() { }
            public Event(string name, string description, string contactEmail)
            {
                Name = name;
                Description = description;
                ContactEmail = contactEmail;
                Id = nextId;
                nextId++;
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }