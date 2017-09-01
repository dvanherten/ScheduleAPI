using System;

namespace Schedules
{
    public sealed class DateTimeNow : IDateTimeNow
    {
        public DateTime UtcNow => DateTime.UtcNow;
        public DateTime Now => DateTime.Now;
    }
}