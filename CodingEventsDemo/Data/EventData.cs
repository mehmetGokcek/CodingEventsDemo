﻿using CodingEventsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Data
{
    public class EventData
    {
        static private Dictionary<int, Event> Events = new Dictionary<int, Event>();

        // GetAll
        public static IEnumerable<Event> GetAll()
        {
            return Events.Values;
        }

        // Add
        public static void Add(Event newEvent)
        {
            Events.Add(newEvent.Id, newEvent);
        }

        // Remove
        public static void Remove(int id)
        {
            Events.Remove(id);
        }

        // GetById
        public static Event GetById(int id)
        {
            return Events[id];
        }

        public static void Edit(int eventId, string name, string description)
        {
                foreach (Event item in GetAll())
                {
                    if (item.Id == eventId) 
                    {
                        item.Name = name;
                        item.Description = description;
                    }
                }
         }
    }
}