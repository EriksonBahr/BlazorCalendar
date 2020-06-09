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
}