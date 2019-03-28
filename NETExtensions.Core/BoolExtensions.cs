using System;
namespace System
{
    public static class BoolExtensions
    {
        public static string ToString(this bool source, string trueString, string falseString)
        {
            return source ? trueString : falseString;
        }

        public static void DoIf(this bool source, Action trueAction, Action falseAction)
        {
            if (source)
                trueAction();
            else
                falseAction();
        }

        public static void DoIfTrue(this bool source, Action trueAction)
        {
            if (source)
                trueAction();
        }

        public static void DoIfFalse(this bool source, Action falseAction)
        {
            if (!source)
                falseAction();
        }
    }
}
