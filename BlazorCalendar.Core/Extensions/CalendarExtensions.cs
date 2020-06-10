using BlazorCalendar.Models;
using System;

namespace BlazorCalendar.Core.CalendarExtensions
{
    public static class CalendarDayExtension
    {
        public static string BuildCssClasses(this CalendarDay calendarDay)
        {
            var stringDayClass = calendarDay.Date == DateTime.Now.Date ? "current-day" : "";
            stringDayClass += calendarDay.IsEmpty ? " disabled-day" : "";
            return stringDayClass;
        }

        public static string BuildCssClasses(this CalendarDay calendarDay, CalendarDay selectedDay)
        {
            var stringDayClass = calendarDay.BuildCssClasses();
            stringDayClass += calendarDay == selectedDay ? " selected-day" : "";
            return stringDayClass;
        }
    }

    public static class CalendarEventExtension
    { 
        public static string GetTruncatedSubject(this CalendarEvent calEvent, int maxChars)
        { 
            return calEvent.Subject.Length <= maxChars ? calEvent.Subject : calEvent.Subject.Substring(0, maxChars) + "...";
        }
    }
}