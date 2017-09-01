using System;
using System.Collections.Generic;

namespace Schedules
{
    public class Schedule
    {
        private readonly IRecurrence _recurrence;
        private readonly IDateTimeNow _dateTimeNow;

        internal Schedule(IRecurrence recurrence, IDateTimeNow dateTimeNow)
        {
            _recurrence = recurrence;
            _dateTimeNow = dateTimeNow;
        }

        public IEnumerable<DateTime> GetNextOccurrences(int maxNumberOfOccurences = 1)
        {
            return _recurrence.GetNextOccurrences(_dateTimeNow.UtcNow, maxNumberOfOccurences);
        }
    }
}