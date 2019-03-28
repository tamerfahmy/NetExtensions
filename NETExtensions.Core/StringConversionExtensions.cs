using System;

namespace System
{
    public static class StringConversionExtensions
    {

        /// <summary>
        /// Convert the given string to short.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <returns>A nullable short for the source string.</returns>
        public static short? ToShort(this string source)
        {
            return To<short>(source, short.TryParse);
        }

        /// <summary>
        /// Convert the given string to int.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <returns>an int32 represent the parsed string.</returns>
        public static int? ToInt(this string source)
        {
            return To<int>(source, int.TryParse);
        }

        /// <summary>
        /// Convert the given string to long.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <returns>a long represent the parsed string.</returns>
        public static long? ToLong(this string source)
        {
            return To<long>(source, long.TryParse);
        }

        /// <summary>
        /// Convert the given string to decimal.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <returns>a decimal represent the parsed string.</returns>
        public static Decimal? ToDecimal(this string source)
        {
            return To<Decimal>(source, Decimal.TryParse);
        }

        /// <summary>
        /// Convert the given string to float.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <returns>a float represent the parsed string.</returns>
        public static float? ToFloat(this string source)
        {
            return To<float>(source, float.TryParse);
        }

        /// <summary>
        /// Convert the given string to double.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <returns>a double represent the parsed string.</returns>
        public static Double? ToDouble(this string source)
        {
            return To<Double>(source, Double.TryParse);
        }

        /// <summary>
        /// Convert the given string to bool.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <returns>a bool represent the parsed string.</returns>
        public static bool? ToBool(this string source)
        {
            string boolString = source;

            if (!boolString.IsNull() && boolString.IsNumber())
            {
                boolString = boolString.Trim();

                if (boolString == "0")
                    return false;
                else if (boolString == "1")
                    return true;
                else
                    return null;
            }
            else
                return To<bool>(boolString, bool.TryParse);
        }

        /// <summary>
        /// Convert the given string to byte.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <returns>a byte represent the parsed string.</returns>
        public static byte? ToByte(this string source)
        {
            return To<byte>(source, byte.TryParse);
        }

        /// <summary>
        /// Convert the given string to DateTime.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <returns>a DateTime represent the parsed string.</returns>
        public static DateTime? ToDateTime(this string source, DateTimeKind dateTimeKind = DateTimeKind.Unspecified)
        {
            var result = To<DateTime>(source, DateTime.TryParse);

            if (result.HasValue && dateTimeKind != DateTimeKind.Unspecified)
                result = result.Value.WithDateTimeKind(dateTimeKind);

            return result;
        }

        /// <summary>
        /// Convert the given string to DateTime.
        /// </summary>
        /// <returns>The date time.</returns>
        /// <param name="source">The source string.</param>
        /// <param name="provider">Formate provider.</param>
        /// <param name="dateTimeStyle">Date time style.</param>
        public static DateTime? ToDateTime(this string source, IFormatProvider provider, Globalization.DateTimeStyles dateTimeStyle, DateTimeKind dateTimeKind = DateTimeKind.Unspecified)
        {
            if (source.IsNullOrEmpty())
                return null;
            else
            {
                var parseSucceeded = DateTime.TryParse(source, provider, dateTimeStyle, out DateTime output);
                if (parseSucceeded)
                {
                    if (dateTimeKind != DateTimeKind.Unspecified)
                        output = output.WithDateTimeKind(dateTimeKind).Value;

                    return output;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Convert the given string to DateTime.
        /// </summary>
        /// <returns>The date time.</returns>
        /// <param name="source">The source string.</param>
        /// <param name="format">Format.</param>
        /// <param name="provider">Formate provider.</param>
        /// <param name="dateTimeStyle">Date time style.</param>
        public static DateTime? ToDateTime(this string source, string format, IFormatProvider provider, Globalization.DateTimeStyles dateTimeStyle, DateTimeKind dateTimeKind = DateTimeKind.Unspecified)
        {
            if (source.IsNullOrEmpty())
                return null;
            else
            {
                var parseSucceeded = DateTime.TryParseExact(source, format, provider, dateTimeStyle, out DateTime output);
                if (parseSucceeded)
                {
                    if (dateTimeKind != DateTimeKind.Unspecified)
                        output = output.WithDateTimeKind(dateTimeKind).Value;

                    return output;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Convert string to GUID.
        /// </summary>
        /// <returns>The GUID.</returns>
        /// <param name="source">Source string.</param>
        public static Guid? ToGuid(this string source)
        {
            if (source.IsNullOrEmpty())
                return null;
            else
                return To<Guid>(source, Guid.TryParse);
        }

        /// <summary>
        /// Convert string the enum.
        /// </summary>
        /// <returns>The enum vale.</returns>
        /// <param name="source">Source string.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T? ToEnum<T>(this string source) where T : struct
        {
            if (source.IsNullOrEmpty())
                return null;
            else
                return (T)Enum.Parse(typeof(T), source);
        }

        #region Private Methods
        /// <summary>
        /// Represent the delegate for try parse.
        /// </summary>
        private delegate bool TryParseDelegate<T>(string source, out T output);

        /// <summary>
        /// Convert the given string to the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source string.</param>
        /// <param name="parseFunc">The parse function used to parse the string.</param>
        /// <returns>specified type</returns>
        private static T? To<T>(string source, TryParseDelegate<T> parseFunc) where T : struct
        {
            if (source.IsNullOrEmpty())
                return null;
            else
            {
                var parseSucceeded = parseFunc(source, out T output);
                if (parseSucceeded)
                    return (T?)output;
                else
                    return null;
            }
        }

        #endregion
    }
}
