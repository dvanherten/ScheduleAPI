using System;

namespace Schedules.Builder
{
    public interface IRecurrenceStep
    {
        IRecurrenceStep WithDateTimeNow(IDateTimeNow dateTimeNow);
        IBuildableSchedule WithSingleRecurrence();
        IBuildableSchedule WithWeeklyRecurrence(RecurrenceDays recurrenceDays);
    }
}