using System;
namespace System.Collections.Generic
{
    public static class CollectionExtenstions
    {
        public static bool IsEmpty<T>(this ICollection<T> collection)
        {
            return collection?.Count == 0;
        }

        public static bool IsNotEmpty<T>(this ICollection<T> collection)
        {
            return !collection.IsEmpty();
        }

        public static string Concatenate<T>(this ICollection<T> collection, Func<T, string> stringFunction, string separator = "")
        {
            var sb = new Text.StringBuilder();

            if (collection.IsNotEmpty())
            {
                foreach (var item in collection)
                {
                    sb.Append(stringFunction(item));

                    if (separator != "")
                        sb.Append(separator);
                }
            }

            string result = sb.ToString();
            if(separator != "")
            {
                int lastSpearatorIndex = result.LastIndexOf(separator);
                return result.Substring(0, lastSpearatorIndex);
            }

            return result;
        }
    }
}
