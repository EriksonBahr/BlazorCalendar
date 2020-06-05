using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorCalendar.Models;
using BlazorCalendar.Services;

namespace BlazorCalendar.Core
{
    public class CalendarController
    {
        public static readonly int COUNT_DAYS_IN_CALENDAR = 42; //todo: must do better. enum instead?
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

        public List<CalendarDay> BuildMonthCalendarDays(int year, int month)
        {
            var days = new List<CalendarDay>();
            var firstDayDate = new DateTime(year, month, 1);
            var weekDayNumber = (int)firstDayDate.DayOfWeek;
            var numberOfEmptyDays = weekDayNumber;

            var lastDayInPrevMonth = DateTime.DaysInMonth(month > 0 ? year : year - 1, month > 1 ? month - 1 : 12);
            //add empty days
            for (int i = numberOfEmptyDays; i > 0; i--)
            {
                days.Add(new CalendarDay
                {
                    DayNumber = lastDayInPrevMonth - i + 1,
                    IsEmpty = true
                });
            }

            int numberIsDaysInMonth = DateTime.DaysInMonth(year, month);
            for (int i = 0; i < numberIsDaysInMonth; i++)
            {
                days.Add(new CalendarDay
                {
                    DayNumber = i + 1,
                    IsEmpty = false,
                    Date = new DateTime(year, month, i + 1)
                });
            }

            int remainingDays = COUNT_DAYS_IN_CALENDAR - days.Count;
            for (int i = 0; i < remainingDays; i++)
            {
                days.Add(new CalendarDay
                {
                    DayNumber = i + 1,
                    IsEmpty = true
                });
            }

            return days;

        }
    }
}