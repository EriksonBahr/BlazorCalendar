using System;

namespace BlazorCalendar.Models
{
    public class CalendarEvent
    {
        public CalendarEvent()
        {
            Color = GetRandomColorClass();
        }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Color { get; set; }

         private string GetRandomColorClass(){
            string[] colors = new[] {"magenta", "yellow", "yellow-green", "pink-red", "red-orange"};
            var random = new Random();
            return colors[random.Next(0, colors.Length)];
        }
    }
}