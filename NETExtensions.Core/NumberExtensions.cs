using System;
namespace System
{
    public static class NumberExtensions
    {
        /// <summary>
        /// Is in the range.
        /// </summary>
        /// <returns><c>true</c>, if in the sepcified range, <c>false</c> otherwise.</returns>
        /// <param name="number">Number.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public static bool InRange(this int number, int min, int max)
        {
            return number >= min && number <= max;
        }

        /// <summary>
        /// Not in the specified range.
        /// </summary>
        /// <returns><c>true</c>, if not in the range, <c>false</c> otherwise.</returns>
        /// <param name="number">Number.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public static bool NotInRange(this int number, int min, int max)
        {
            return !number.InRange(min, max);
        }

        /// <summary>
        /// Is in the range.
        /// </summary>
        /// <returns><c>true</c>, if in the sepcified range, <c>false</c> otherwise.</returns>
        /// <param name="number">Number.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public static bool InRange(this short number, short min, short max)
        {
            return number >= min && number <= max;
        }

        /// <summary>
        /// Not in the specified range.
        /// </summary>
        /// <returns><c>true</c>, if not in the range, <c>false</c> otherwise.</returns>
        /// <param name="number">Number.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public static bool NotInRange(this short number, short min, short max)
        {
            return !number.InRange(min, max);
        }

        /// <summary>
        /// Is in the range.
        /// </summary>
        /// <returns><c>true</c>, if in the sepcified range, <c>false</c> otherwise.</returns>
        /// <param name="number">Number.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public static bool InRange(this long number, long min, long max)
        {
            return number >= min && number <= max;
        }

        /// <summary>
        /// Not in the specified range.
        /// </summary>
        /// <returns><c>true</c>, if not in the range, <c>false</c> otherwise.</returns>
        /// <param name="number">Number.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public static bool NotInRange(this long number, long min, long max)
        {
            return !number.InRange(min, max);
        }

        /// <summary>
        /// Is in the range.
        /// </summary>
        /// <returns><c>true</c>, if in the sepcified range, <c>false</c> otherwise.</returns>
        /// <param name="number">Number.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public static bool InRange(this double number, double min, double max)
        {
            return number >= min && number <= max;
        }

        /// <summary>
        /// Not in the specified range.
        /// </summary>
        /// <returns><c>true</c>, if not in the range, <c>false</c> otherwise.</returns>
        /// <param name="number">Number.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public static bool NotInRange(this double number, double min, double max)
        {
            return !number.InRange(min, max);
        }

        /// <summary>
        /// Is in the range.
        /// </summary>
        /// <returns><c>true</c>, if in the sepcified range, <c>false</c> otherwise.</returns>
        /// <param name="number">Number.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public static bool InRange(this decimal number, decimal min, decimal max)
        {
            return number >= min && number <= max;
        }

        /// <summary>
        /// Not in the specified range.
        /// </summary>
        /// <returns><c>true</c>, if not in the range, <c>false</c> otherwise.</returns>
        /// <param name="number">Number.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public static bool NotInRange(this decimal number, decimal min, decimal max)
        {
            return !number.InRange(min, max);
        }

        /// <summary>
        /// Is in the range.
        /// </summary>
        /// <returns><c>true</c>, if in the sepcified range, <c>false</c> otherwise.</returns>
        /// <param name="number">Number.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public static bool InRange(this float number, float min, float max)
        {
            return number >= min && number <= max;
        }

        /// <summary>
        /// Not in the specified range.
        /// </summary>
        /// <returns><c>true</c>, if not in the range, <c>false</c> otherwise.</returns>
        /// <param name="number">Number.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public static bool NotInRange(this float number, float min, float max)
        {
            return !number.InRange(min, max);
        }
    }
}
