using System;
using System.Reflection;

namespace System
{
    public static class GernericsExtensions
    {
        public static bool IsNull<T>(this T source) where T : class
        {
            return source == null;
        }

        public static bool IsNotNull<T>(this T source) where T : class
        {
            return !source.IsNull();
        }

        public static bool In<T>(this T source, params T[] values)
        {
            bool elementFound = false;
            foreach (var value in values)
            {
                if (source.Equals(value))
                {
                    elementFound = true;
                    break;
                }
            }
            return elementFound;
        }

        public static bool NotIn<T>(this T source, params T[] values)
        {
            return !source.In(values);
        }

        public static bool In<T>(this T source, Func<T, T, bool> compareFunc, params T[] values)
        {
            bool elementFound = false;
            foreach (var value in values)
            {
                if (compareFunc(source, value))
                {
                    elementFound = true;
                    break;
                }
            }
            return elementFound;
        }

        public static bool NotIn<T>(this T source, Func<T, T, bool> compareFunc, params T[] values)
        {
            return !source.In(compareFunc, values);
        }

        public static TTarget As<TSource, TTarget>(this TSource source) where TSource : class where TTarget:class
        {
            return source as TTarget;
        }

        public static TTarget As<TTarget>(this object source) where TTarget : class
        {
            return source as TTarget;
        }

        public static T Coalesce<T>(this T source, T defaultValue) where T : class
        {
            if (source.IsNull())
                return defaultValue;
            else
                return source;
        }

        public static T Coalesce<T>(this T source) where T : class, new()
        {
            if (source.IsNull())
                return source.Coalesce(new T());
            else
                return source;
        }


        public static TTarget CopyRunTimeProperties<TSource, TTarget>(this TSource source) where TSource :class where TTarget : class, new()
        {
            if (source.IsNull())
                return null;
            else
            {
                var result = new TTarget();

                var properties = source.GetType().GetRuntimeProperties();
                Type targetType = typeof(TTarget);

                foreach (var p in properties)
                {
                    if (p.CanRead)
                    {
                        var p2 = targetType.GetRuntimeProperty(p.Name);
                        if (p2 != null && p2.CanWrite)
                        {
                            var val = p.GetValue(source, null);
                            if (val != null)
                                p2.SetValue(result, val, null);
                        }
                    }
                }

                return result;
            }
        }
    }
}
