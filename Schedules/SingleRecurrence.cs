using System;
using System.Collections.Generic;

namespace Schedules
{
    public class SingleRecurrence : IRecurrence
    {
        private readonly DateTime _startDate;

        public SingleRecurrence(DateTime startDate)
        {
            _startDate = startDate;
        }

        public IEnumerable<DateTime> GetNextOccurrences(DateTime utcNow, int maxNumberOfOccurences)
        {
            if (maxNumberOfOccurences <= 0) throw new ArgumentOutOfRangeException(nameof(maxNumberOfOccurences));

            if (_startDate > utcNow)
                yield return _startDate;
        }
    }
}