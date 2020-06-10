using BlazorCalendar.Core.CalendarExtensions;
using BlazorCalendar.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCalendar.Core.Tests
{
    public class CalendarDayExtensionsTests
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

    public class CalendarEventTests {

        [TestCase]
        public void ShallTruncateTooBigSubjects() {
            var calEvent = new CalendarEvent { Subject = "This is a very big subject and needs to be truncated" };
            string subject = calEvent.GetTruncatedSubject(5);
            Assert.That(subject.Length, Is.EqualTo(8));
            Assert.That(subject.EndsWith("..."));
        }

        [TestCase]
        public void ShallReturnStringIfNotTooBig() {
            var calEvent = new CalendarEvent { Subject = "Small description" };
            string subject = calEvent.GetTruncatedSubject(18);
            Assert.That(subject, Is.EqualTo(calEvent.Subject));
        }

    }
}
