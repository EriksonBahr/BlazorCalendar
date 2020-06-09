using BlazorCalendar.Core.CalendarExtensions;
using BlazorCalendar.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCalendar.Core.Tests
{
    public class CalendarExtensionsTests
    {

        [TestCase]
        public void ShallBeAbleToBuildCSSClassesForToday() {
            var cssClasses = new CalendarDay { Date = DateTime.Today }.BuildCssClasses();
            Assert.That(cssClasses, Is.EqualTo("current-day"));
        }

        [TestCase]
        public void ShallReturnCSSClassesForDisabledDay() {
            var cssClasses = new CalendarDay { Date = DateTime.Today.AddDays(-1), IsEmpty = true}.BuildCssClasses();
            Assert.That(cssClasses.Contains("disabled-day"));
        }

        [TestCase]
        public void ShallReturnCSSClassesForSelectedDay() {
            var day = new CalendarDay();
            var cssClasses = day.BuildCssClasses(day);
            Assert.That(cssClasses.Contains("selected-day"));
        }

        [TestCase]
        public void ShallReturnCSSClassesForTodayThatIsSelected() {
            var day = new CalendarDay{ Date = DateTime.Today };
            var cssClasses = day.BuildCssClasses(day);
            Assert.That(cssClasses.Contains("selected-day"));
            Assert.That(cssClasses.Contains("current-day"));
            Assert.That(cssClasses.Trim().Contains(" "));
        }
    }
}
