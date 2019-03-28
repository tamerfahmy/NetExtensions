using System;
using System.Collections.Generic;

namespace System
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Validate if the datetime object is not equal to DateTime.MinValue and not equal to DateTime.MaxValue
        /// </summary>
        /// <returns><c>true</c>, if valid, <c>false</c> otherwise.</returns>
        /// <param name="dateTime">Date time.</param>
        public static bool IsValid(this DateTime dateTime)
        {
            return dateTime != DateTime.MinValue && dateTime != DateTime.MaxValue;
        }

        /// <summary>
        /// Validate if the datetime object is equal to DateTime.MinValue or equal to DateTime.MaxValue
        /// </summary>
        /// <returns><c>true</c>, if valid, <c>false</c> otherwise.</returns>
        /// <param name="dateTime">Date time.</param>
        public static bool IsNotValid(this DateTime dateTime)
        {
            return !dateTime.IsValid();
        }

        /// <summary>
        /// Create a new instact of DateTime with the same year, month, day, hour, minute, secod and the specified DateTimeKind
        /// </summary>
        /// <returns>The date time kind.</returns>
        /// <param name="dateTime">Date time.</param>
        /// <param name="dateTimeKind">Date time kind.</param>
        public static DateTime? WithDateTimeKind(this DateTime dateTime, DateTimeKind dateTimeKind)
        {
            if (dateTime == null)
                return null;
            else
            {
                return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                    dateTime.Hour, dateTime.Minute, dateTime.Minute,
                                    dateTimeKind);
            }
        }

        /// <summary>
        /// Validate the date to be within min and max date range
        /// </summary>
        /// <returns><c>true</c>, if in range, <c>false</c> otherwise.</returns>
        /// <param name="dateTime">Date time.</param>
        /// <param name="minDate">Minimum date.</param>
        /// <param name="maxDate">Max date.</param>
        public static bool InRange(this DateTime dateTime, DateTime minDate, DateTime maxDate)
        {
            return dateTime >= minDate && dateTime <= maxDate;
        }

        /// <summary>
        /// Validates that the date is not in min and max date range
        /// </summary>
        /// <returns><c>true</c>, if not it the range, <c>false</c> otherwise.</returns>
        /// <param name="dateTime">Date time.</param>
        /// <param name="minDate">Minimum date.</param>
        /// <param name="maxDate">Max date.</param>
        public static bool NotInRange(this DateTime dateTime, DateTime minDate, DateTime maxDate)
        {
            return !dateTime.InRange(minDate, maxDate);
        }


        public static bool IsPast(this DateTime dateTime)
        {
            return dateTime < DateTime.Now;
        }

        public static bool IsFuture(this DateTime dateTime)
        {
            return dateTime > DateTime.Now;
        }

        public static bool IsToday(this DateTime dateTime)
        {
            return dateTime.Date == DateTime.Today;
        }

        public static DateTime Yesterday(this DateTime dateTime)
        {
            return dateTime.AddDays(-1);
        }

        public static DateTime Tomorrow(this DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }

        public static double Age(this DateTime birthdate)
        {
            if (!birthdate.IsPast())
                return 0;
            else
            {
                var ageInDays = DateTime.Now.Subtract(birthdate).TotalDays;
                return ageInDays / 365;
            }
        }

        public static bool IsTimeEqual(this DateTime dateTime, DateTime otherDateTime)
        {
            return dateTime.TimeOfDay == otherDateTime.TimeOfDay;
        }

        public static bool IsDateEqual(this DateTime dateTime, DateTime otherDateTime)
        {
            return dateTime.Date == otherDateTime.Date;
        }

        public static DateTime SetTime(this DateTime dateTime, TimeSpan timeSpan)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
                                dateTime.Kind);
        }

        public static DateTime ToTimeZone(this DateTime dateTime, TimeZoneInfo targetTimeZone)
        {
            return TimeZoneInfo.ConvertTime(dateTime, targetTimeZone);
        }

        public static bool IsLeapYear(this DateTime dateTime)
        {
            return DateTime.IsLeapYear(dateTime.Year);
        }

        public static TimeSpan Elapsed(this DateTime dateTime)
        {
            return DateTime.Now.Subtract(dateTime);
        }

        public static DateTime NextWeek(this DateTime dateTime)
        {
            return dateTime.AddDays(7);
        }

        public static DateTime LastWeek(this DateTime dateTime)
        {
            return dateTime.AddDays(-7);
        }

        public static DateTime NextMonth(this DateTime dateTime)
        {
            return dateTime.AddMonths(1);
        }

        public static DateTime LastMonth(this DateTime dateTime)
        {
            return dateTime.AddMonths(-1);
        }

        public static DateTime NextYear(this DateTime dateTime)
        {
            return dateTime.AddYears(1);
        }

        public static DateTime LastYear(this DateTime dateTime)
        {
            return dateTime.AddYears(-1);
        }
    }
}
