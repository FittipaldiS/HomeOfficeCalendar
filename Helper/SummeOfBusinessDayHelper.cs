using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeOffice.Calendar.Helper
{
    public static class SummeOfBusinessDayHelper
    {
        private const int DAYS_OF_MONTH_WITH_30 = 30;
        private const int DAYS_OF_MONTH_WITH_31 = 31;
        private const int DAYS_OF_MONTH_WITH_28 = 28;
        private const int FEBRUARY = 2;
        private const int NOVEMBER = 11;
        private const int APRIL = 4;
        private const int SEPTEMBER = 9;
        private const int JUNE = 6;

        public static int GetBusinessDay(DateTime date)
        {
            var businessDay = 0;
            var actualDate = date;
            var count = 0;

            var daysOfTheMonth = GetMonthDays(date.Month, date.Year);

            for (int i = date.Day; i <= daysOfTheMonth; i++)
            {
                var dateFuture = actualDate.AddDays(count);

                if ((dateFuture.DayOfWeek == DayOfWeek.Sunday || dateFuture.DayOfWeek == DayOfWeek.Saturday) == false)
                {
                    businessDay++;
                }

                count++;
            }

            return businessDay;
        }

        private static int GetMonthDays(int month, int year)
        {
            int days;
            if ((month == NOVEMBER || month == APRIL || month == JUNE || month == SEPTEMBER) == true)
            {
                days = DAYS_OF_MONTH_WITH_30;
            }
            else if (month == FEBRUARY)
            {
                //Anno bisestile
                var days_of_febraury = DateTime.IsLeapYear(year) == true ? DAYS_OF_MONTH_WITH_28 + 1 : DAYS_OF_MONTH_WITH_28;

                days = days_of_febraury;

            }
            else
            {
                days = DAYS_OF_MONTH_WITH_31;
            }

            return days;
        }

        public static bool IsBusinessDay(DateTime date)
        {
            return
                date.DayOfWeek != DayOfWeek.Saturday &&
                date.DayOfWeek != DayOfWeek.Sunday;
        }
    }
}
