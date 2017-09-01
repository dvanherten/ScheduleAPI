using System;

namespace Schedules.Tests
{
    public class FakeDateTimeNow : IDateTimeNow
    {
        public DateTime Now { get; }
        public DateTime UtcNow { get; }

        public FakeDateTimeNow(DateTime date)
        {
            Now = date;
            UtcNow = date;
        }
    }
}