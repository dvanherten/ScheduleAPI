using System;

namespace Schedules.Builder
{
    public class ScheduleBuilder : IRecurrenceStep, IBuildableSchedule
    {
        private DateTime _startDate;
        private IDateTimeNow _dateTimeNow = new DateTimeNow();
        private IRecurrence _recurrence;

        private ScheduleBuilder(DateTime startDate)
        {
            _startDate = startDate;
        }

        public IRecurrenceStep WithDateTimeNow(IDateTimeNow dateTimeNow)
        {
            _dateTimeNow = dateTimeNow;
            return this;
        }

        public static IRecurrenceStep Starting(DateTime startDate)
        {
            return new ScheduleBuilder(startDate);
        }

        public IBuildableSchedule WithSingleRecurrence()
        {
            _recurrence = new SingleRecurrence(_startDate);
            return this;
        }

        public IBuildableSchedule WithWeeklyRecurrence(RecurrenceDays recurrenceDays)
        {
            _recurrence = new WeeklyRecurrence(_startDate, recurrenceDays);
            return this;
        }

        public Schedule Build()
        {
            return new Schedule(_recurrence, _dateTimeNow);
        }
    }
}
