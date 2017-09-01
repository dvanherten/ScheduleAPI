using System;
using System.Collections.Generic;

namespace Schedules
{
    public interface IRecurrence
    {
        IEnumerable<DateTime> GetNextOccurrences(DateTime utcNow, int maxNumberOfOccurences);
    }
}