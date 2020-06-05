using BlazorCalendar.Models;
using BlazorCalendar.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCalendar.Core.Tests
{
    public class CalendarControllerTests
    {
        [TestCase]
        public async System.Threading.Tasks.Task ShallReturnCalendarEventsFromProviderAsync() {
            var calendarEventsProviderMock = new Mock<ICalendarEventsProvider>();
            calendarEventsProviderMock.Setup(p => p.GetEventsInMonthAsync(It.IsAny<int>(), It.IsAny<int>())).Returns(() =>  {
                
                var cal = new CalendarEvent()
                {
                    Subject = "MySubject",
                    StartDate = new DateTime(2020, 6, 1),
                    EndDate = new DateTime(2020, 6, 1)
                };

                var result = new ConcurrentBag<CalendarEvent>();
                result.Add(cal);
                return Task.FromResult<ConcurrentBag<CalendarEvent>>(result);

            });
            var calendarController = new CalendarController(calendarEventsProviderMock.Object);

            var result = await calendarController.GetEventsInMonthAsync(2020, 6);
            calendarEventsProviderMock.Verify(p => p.GetEventsInMonthAsync(2020, 6), Times.Once);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.First().EndDate, Is.EqualTo(new DateTime(2020, 6, 1)));
        }

        [TestCase]
        public async Task ShallAddCalendarEvents() {
            var calendarEventsProviderMock = new Mock<ICalendarEventsProvider>();
            var calendarController = new CalendarController(calendarEventsProviderMock.Object);
            await calendarController.AddEventAsync(new CalendarEvent { Subject = "Mock"});
            calendarEventsProviderMock.Verify(p => p.AddEventAsync(It.IsAny<CalendarEvent>()), Times.Once);
        }
    }
}
