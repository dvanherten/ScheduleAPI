using System;
using System.Collections.Generic;

namespace Schedules
{
    public class Schedule
    {
        private readonly IDateTimeNow _dateTimeNow;

        internal Schedule(IRecurrence recurrence, IDateTimeNow dateTimeNow)
        {
            Recurrence = recurrence;
            _dateTimeNow = dateTimeNow;
        }

        public IRecurrence Recurrence { get; }

        public IEnumerable<DateTime> GetNextOccurrences(int maxNumberOfOccurences = 1)
        {
            return Recurrence.GetNextOccurrences(_dateTimeNow.UtcNow, maxNumberOfOccurences);
        }
    }
}