using System;
using System.Collections.Generic;

namespace BlazorCalendar.Models
{
    public class CalendarDay {
        public CalendarDay()
        {
            Events = new List<CalendarEvent>();
        }
        public int DayNumber { get; set; }
        public DateTime Date { get; set; }
        public bool IsEmpty {get; set;}

        public List<CalendarEvent> Events {get; set;}
    }
}

