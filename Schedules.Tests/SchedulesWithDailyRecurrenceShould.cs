using System;
using System.Linq;
using FluentAssertions;
using Schedules.Builder;
using Xunit;

namespace Schedules.Tests
{
    public class SchedulesWithDailyRecurrenceShould
    {
        [Theory]
        [InlineData(RecurrenceDays.Monday, 8, 28)]
        [InlineData(RecurrenceDays.Tuesday, 8, 29)]
        [InlineData(RecurrenceDays.Wednesday, 8, 30)]
        [InlineData(RecurrenceDays.Thursday, 8, 31)]
        [InlineData(RecurrenceDays.Friday, 9, 1)]
        [InlineData(RecurrenceDays.Saturday, 9, 2)]
        [InlineData(RecurrenceDays.Sunday, 9, 3)]
        public void ReturnCorrectDayOccurenceWithSpecificRecurrenceAndTimeHasPassedToday(RecurrenceDays recurrenceDays,
            int month, int day)
        {
            var startDate = new DateTime(2017, 8, 27, 8, 30, 0);
            var fakeNow = new DateTime(2017, 8, 27, 9, 30, 0);
            var expectedDate = new DateTime(2017, month, day, 8, 30, 0);

            var schedule = ScheduleBuilder
                .Starting(startDate)
                .WithDateTimeNow(new FakeDateTimeNow(fakeNow))
                .WithDailyRecurrence(recurrenceDays)
                .Build();

            var dates = schedule.GetNextOccurrences().ToArray();
            dates.ShouldBeEquivalentTo(new[] {expectedDate});
        }

        [Fact]
        public void ReturnThreeWeeksOfWednesdayAndFridays()
        {
            var startDate = new DateTime(2017, 8, 27, 8, 30, 0);
            var fakeNow = new DateTime(2017, 8, 27, 9, 30, 0);
            var expectedDate = new DateTime(2017, 8, 30, 8, 30, 0);

            var schedule = ScheduleBuilder
                .Starting(startDate)
                .WithDateTimeNow(new FakeDateTimeNow(fakeNow))
                .WithDailyRecurrence(RecurrenceDays.Wednesday | RecurrenceDays.Friday)
                .Build();

            var dates = schedule.GetNextOccurrences(6).ToArray();
            dates.ShouldBeEquivalentTo(new[]
            {
                expectedDate,
                expectedDate.AddDays(2),
                expectedDate.AddDays(7),
                expectedDate.AddDays(9),
                expectedDate.AddDays(14),
                expectedDate.AddDays(16)
            });
        }

        [Fact]
        public void ReturnTodayOccurenceWithEverydayRecurrenceAndTimeHasNotPassedToday()
        {
            var startDate = new DateTime(2017, 8, 31, 9, 30, 0);
            var fakeNow = new DateTime(2017, 8, 31, 8, 30, 0);
            var expectedDate = startDate;

            var schedule = ScheduleBuilder
                .Starting(startDate)
                .WithDateTimeNow(new FakeDateTimeNow(fakeNow))
                .WithDailyRecurrence(RecurrenceDays.Everyday)
                .Build();

            var dates = schedule.GetNextOccurrences().ToArray();
            dates.ShouldBeEquivalentTo(new[] {expectedDate});
        }

        [Fact]
        public void ReturnTomorrowsOccurenceWithEverydayRecurrenceAndTimeHasPassedToday()
        {
            var startDate = new DateTime(2017, 8, 30, 8, 30, 0);
            var fakeNow = new DateTime(2017, 8, 31, 9, 30, 0);
            var expectedDate = startDate.AddDays(2);

            var schedule = ScheduleBuilder
                .Starting(startDate)
                .WithDateTimeNow(new FakeDateTimeNow(fakeNow))
                .WithDailyRecurrence(RecurrenceDays.Everyday)
                .Build();

            var dates = schedule.GetNextOccurrences().ToArray();
            dates.ShouldBeEquivalentTo(new[] {expectedDate});
        }
    }
}