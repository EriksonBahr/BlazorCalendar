using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using BlazorCalendar.Models;
using BlazorCalendar.Services;

namespace BlazorCalendar.Core
{
    public class CalendarController
    {
        private ICalendarEventsProvider calendarEventsProvider;

        public CalendarController(ICalendarEventsProvider calendarEventsProvider)
        {
            this.calendarEventsProvider = calendarEventsProvider;
        }

        public Task<ConcurrentBag<CalendarEvent>> GetEventsInMonthAsync(int year, int month)
        {
            return calendarEventsProvider.GetEventsInMonthAsync(year, month);
        }
    }
}