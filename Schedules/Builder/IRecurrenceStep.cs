using System;

namespace Schedules.Builder
{
    public interface IRecurrenceStep
    {
        IRecurrenceStep WithDateTimeNow(IDateTimeNow dateTimeNow);
        IBuildableSchedule WithSingleRecurrence();
        IBuildableSchedule WithDailyRecurrence(RecurrenceDays recurrenceDays);
    }
}