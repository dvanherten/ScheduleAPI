using System;
using System.Collections.Generic;

namespace Schedules
{
    public class WeeklyRecurrence : IRecurrence
    {
        private readonly DateTime _startDate;
        private readonly RecurrenceDays _recurrenceDays;

        public WeeklyRecurrence(DateTime startDate, RecurrenceDays recurrenceDays)
        {
            _startDate = startDate;
            _recurrenceDays = recurrenceDays;
        }

        public IEnumerable<DateTime> GetNextOccurrences(DateTime now, int maxNumberOfOccurences)
        {
            if (maxNumberOfOccurences <= 0) throw new ArgumentOutOfRangeException(nameof(maxNumberOfOccurences));

            var occurences = 0;
            var possibleDayToReturn = DateTime.SpecifyKind(new DateTime(now.Year, now.Month, now.Day, _startDate.Hour, _startDate.Minute, _startDate.Second), now.Kind);
            while (occurences < maxNumberOfOccurences)
            {
                if (possibleDayToReturn > now && IsRecurrenceDay(possibleDayToReturn))
                {
                    yield return possibleDayToReturn;
                    occurences++;
                }
                possibleDayToReturn = possibleDayToReturn.AddDays(1);
            }
        }

        private bool IsRecurrenceDay(DateTime dateTime)
        {
            return _recurrenceDays.HasFlag(Enum.Parse<RecurrenceDays>(dateTime.DayOfWeek.ToString()));
        }
    }
}