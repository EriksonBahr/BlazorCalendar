using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BlazorCalendar.Models
{
    public class CalendarDay {
        public CalendarDay()
        {
            Events = new ConcurrentBag<CalendarEvent>();
        }
        public int DayNumber { get; set; }
        public DateTime Date { get; set; }
        public bool IsEmpty {get; set;}

        public ConcurrentBag<CalendarEvent> Events {get; set;}
    }
}

