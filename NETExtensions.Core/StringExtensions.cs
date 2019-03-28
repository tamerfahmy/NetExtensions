using System;
using System.Collections.Generic;

namespace System
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if the string is null.
        /// </summary>
        /// <returns><c>true</c>, if it is null, <c>false</c> otherwise.</returns>
        /// <param name="source">Source.</param>
        public static bool IsNull(this string source)
        {
            return source == null;
        }

        public static bool IsNotNull(this string source)
        {
            return !source.IsNull();
        }

        /// <summary>
        /// Checks if the string is empty.
        /// </summary>
        /// <returns><c>true</c>, if it is empty, <c>false</c> otherwise.</returns>
        /// <param name="source">Source.</param>
        /// <param name="ignoreWhiteSpace">If set to <c>false</c> the white space will not be ingored.</param>
        public static bool IsEmpty(this string source, bool ignoreWhiteSpace = true)
        {
            if (source.IsNull())
                return true;
            else
            {
                if(ignoreWhiteSpace)
                    return source.Trim().Length == 0;
                else
                    return source.Length == 0;
            }
        }

        public static bool IsNotEmpty(this string source, bool ignoreWhiteSpace = true)
        {
            return !source.IsEmpty(ignoreWhiteSpace);
        }

        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        public static bool IsNotNullOrWhiteSpace(this string source)
        {
            return !source.IsNullOrWhiteSpace();
        }

        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        public static bool IsNotNullOrEmpty(this string source)
        {
            return !source.IsNullOrEmpty();
        }

        /// <summary>
        /// Formats the string source with the paramters.
        /// </summary>
        /// <returns>The with.</returns>
        /// <param name="source">Source.</param>
        /// <param name="args">Arguments.</param>
        public static string FormatWith(this string source, params object[] args)
        {
            if (source.IsNull())
                return null;
            else
                return String.Format(source, args);
        }

        /// <summary>
        /// Validates the source string if it represents a valid email address.
        /// </summary>
        /// <returns><c>true</c>, if valid email, <c>false</c> otherwise.</returns>
        /// <param name="source">Source string.</param>
        public static bool IsEmail(this string source)
        {
            if (source.IsNullOrEmpty())
                return false;
            else
            {
                var expression = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
                return Text.RegularExpressions.Regex.IsMatch(source, expression, Text.RegularExpressions.RegexOptions.IgnoreCase);
            }
        }


        public static bool IsNotEmail(this string source)
        {
            return !source.IsEmail();
        }

        /// <summary>
        /// Validates the source string is a valid number
        /// </summary>
        /// <returns><c>true</c>, if valid number, <c>false</c> otherwise.</returns>
        /// <param name="source">Source string.</param>
        /// <param name="ignoreWhiteSpaces">If set to <c>false</c> will not ignore white spaces.</param>
        public static bool IsNumber(this string source, bool ignoreWhiteSpaces = true)
        {
            if(source.IsNullOrEmpty())
                return false;
            else
            {
                var trimmedSource = source;
                if (ignoreWhiteSpaces)
                    trimmedSource = source.Trim();

                foreach(var @char in trimmedSource)
                {
                    if (!Char.IsNumber(@char))
                        return false;
                }

                return true;
            }
        }

        public static bool IsNotNumber(this string source, bool ignoreWhiteSpaces = true)
        {
            return !source.IsNumber(ignoreWhiteSpaces);
        }

        public static string TakeRight(this string source, int length)
        {
            if (source.IsNullOrEmpty())
                return source;
            else
                return source.Substring(source.Length - length);
        }

        public static string TakeLeft(this string source, int length)
        {
            if (source.IsNullOrEmpty())
                return source;
            else
                return source.Substring(0, length);
        }

        /// <summary>
        /// Concatenate the specified source string and other string values.
        /// </summary>
        /// <returns>The concatenated string.</returns>
        /// <param name="source">Source string.</param>
        /// <param name="otherStrings">Other string values.</param>
        public static string ConcatWith(this string source, params string[] otherStrings)
        {
            var stringCollection = new List<string>
            {
                source
            };

            stringCollection.AddRange(otherStrings);

            return stringCollection.Concatenate();
        }

        /// <summary>
        /// Concatenate the specified source string and other string values.
        /// </summary>
        /// <returns>The concatenated string.</returns>
        /// <param name="source">Source string.</param>
        /// <param name="separator">separator string.</param>
        /// <param name="otherStrings">Other string values.</param>
        public static string ConcatWith(this string source, string separator, params string[] otherStrings)
        {
            var stringCollection = new List<string>
            {
                source
            };

            stringCollection.AddRange(otherStrings);

            return stringCollection.Concatenate(separator);
        }

        /// <summary>
        /// Concatenate the specified string collection.
        /// </summary>
        /// <returns>The concatenated string.</returns>
        /// <param name="stringCollection">String collection.</param>
        public static string Concatenate(this ICollection<string> stringCollection)
        {
            return stringCollection.Concatenate(x => x.ToString());
        }

        /// <summary>
        /// Concatenate the specified string collection.
        /// </summary>
        /// <returns>The concatenated string.</returns>
        /// <param name="stringCollection">String collection.</param>
        public static string Concatenate(this ICollection<string> stringCollection, string separator)
        {
            return stringCollection.Concatenate(x => x.ToString(), separator);
        }


    }
}
