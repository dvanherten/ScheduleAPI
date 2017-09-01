using System;
using System.Linq;
using FluentAssertions;
using Schedules.Builder;
using Xunit;

namespace Schedules.Tests
{
    public class SchedulesWithSingleRecurrenceShould
    {
        [Fact]
        public void HaveASingleNextOccurrenceWhenCurrentDateHasNotPassed()
        {
            var singleDate = new DateTime(2017, 8, 31, 8, 30, 0);
            var fakeNow = new DateTime(2017, 8, 31);

            var schedule = ScheduleBuilder
                .Starting(singleDate)
                .WithDateTimeNow(new FakeDateTimeNow(fakeNow))
                .WithSingleRecurrence()
                .Build();

            var dates = schedule.GetNextOccurrences().ToArray();
            dates.ShouldBeEquivalentTo(new [] {singleDate});
        }

        [Fact]
        public void HaveNoNextOccurrencesWhenCurrentDateHasPassed()
        {
            var singleDate = new DateTime(2017, 8, 31, 8, 30, 0);
            var fakeNow = new DateTime(2017, 9, 10);

            var schedule = ScheduleBuilder
                .Starting(singleDate)
                .WithDateTimeNow(new FakeDateTimeNow(fakeNow))
                .WithSingleRecurrence()
                .Build();

            var dates = schedule.GetNextOccurrences().ToArray();
            dates.ShouldBeEquivalentTo(new DateTime[0]);
        }
    }
}
