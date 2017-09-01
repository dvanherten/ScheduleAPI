using System;

namespace Schedules
{
    public interface IDateTimeNow
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}