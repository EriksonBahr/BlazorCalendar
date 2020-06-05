using BlazorCalendar.Models;
using BlazorCalendar.Services;
using Moq;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace BlazorCalendar.Core.Tests
{
    internal class CalendarController
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

        public Task AddEventAsync(CalendarEvent calendarEvent)
        {
            return calendarEventsProvider.AddEventAsync(calendarEvent);
        }
    }
}