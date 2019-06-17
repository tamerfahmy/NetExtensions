using System;
using System.Reflection;

namespace System {
    public static class GernericsExtensions {
        /// <summary>
        /// Checks wether the instance is null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static bool IsNull<T> (this T source) where T : class {
            return source == null;
        }

        /// <summary>
        /// Checks wether the instance is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static bool IsNotNull<T> (this T source) where T : class {
            return !source.IsNull ();
        }

        /// <summary>
        /// Checks wether the source value is one of the array elements or not
        /// </summary>
        /// <param name="source"></param>
        /// <param name="values">elements array</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>true if the source value in the array elements, in complex data types you are required to implement IEquatable</returns>
        public static bool In<T> (this T source, params T[] values) {
            bool elementFound = false;
            foreach (var value in values) {
                if (source.Equals (value)) {
                    elementFound = true;
                    break;
                }
            }
            return elementFound;
        }

        /// <summary>
        /// Checks wether the source value is one of the array elements or not
        /// </summary>
        /// <param name="source"></param>
        /// <param name="values">elements array</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>true if the source value not in the array elements, in complex data types you are required to implement IEquatable</returns>
        public static bool NotIn<T> (this T source, params T[] values) {
            return !source.In (values);
        }

        /// <summary>
        /// Checks wether the source value is one of the array elements or not based on a func of T
        /// </summary>
        /// <param name="source"></param>
        /// <param name="compareFunc">the compare function of T</param>
        /// <param name="values">array elements</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The compare func return</returns>
        public static bool In<T> (this T source, Func<T, T, bool> compareFunc, params T[] values) {
            bool elementFound = false;
            foreach (var value in values) {
                if (compareFunc (source, value)) {
                    elementFound = true;
                    break;
                }
            }
            return elementFound;
        }

        /// <summary>
        /// Checks wether the source value is one of the array elements or not based on a func of T
        /// </summary>
        /// <param name="source"></param>
        /// <param name="compareFunc">the compare function of T</param>
        /// <param name="values">array elements</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The compare func return</returns>
        public static bool NotIn<T> (this T source, Func<T, T, bool> compareFunc, params T[] values) {
            return !source.In (compareFunc, values);
        }

        /// <summary>
        /// Cast the source the type to the target type
        /// </summary>
        /// <typeparam name="TSource">Source Type</typeparam>
        /// <typeparam name="TTarget">Target type</typeparam>
        public static TTarget As<TSource, TTarget> (this TSource source) where TSource : class where TTarget : class {
            return source as TTarget;
        }

        public static TTarget As<TTarget> (this object source) where TTarget : class {
            return source as TTarget;
        }

        /// <summary>
        /// Returns the default value where the source is null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static T Coalesce<T> (this T source, T defaultValue) where T : class {
            if (source.IsNull ())
                return defaultValue;
            else
                return source;
        }

        /// <summary>
        /// Returns a new T where the source is null, T must have a parameterless constructor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static T Coalesce<T> (this T source) where T : class, new () {
            if (source.IsNull ())
                return source.Coalesce (new T ());
            else
                return source;
        }

        /// <summary>
        /// Copies the runtime properties from source object to target object using reflection
        /// </summary>
        /// <typeparam name="TSource">The source object</typeparam>
        /// <typeparam name="TTarget">The target object</typeparam>
        public static TTarget CopyRunTimeProperties<TSource, TTarget> (this TSource source) where TSource : class where TTarget : class, new () {
            if (source.IsNull ())
                return null;
            else {
                var result = new TTarget ();

                var properties = source.GetType ().GetRuntimeProperties ();
                Type targetType = typeof (TTarget);

                foreach (var p in properties) {
                    if (p.CanRead) {
                        var p2 = targetType.GetRuntimeProperty (p.Name);
                        if (p2 != null && p2.CanWrite) {
                            var val = p.GetValue (source, null);
                            if (val != null)
                                p2.SetValue (result, val, null);
                        }
                    }
                }

                return result;
            }
        }
    }
}