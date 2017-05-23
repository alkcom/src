using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using UnitsNet;
using UnitsNet.Units;

namespace Niscon.Raynok.Extensions
{
    public static class Extensions
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        /// <summary>
        /// Parses length from string
        /// Trying to get units from string, if unsuccessful, falls back to <see cref="LengthUnit.Inch"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Length ParseLength(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Length result;
            double doubleValue;
            if (!Length.TryParse(value, out result) && double.TryParse(value, out doubleValue))
            {
                result = Length.FromInches(doubleValue);
            }

            return result;
        }

        /// <summary>
        /// Parses length units from string
        /// Trying to get units from string, if unsuccessful, falls back to <see cref="LengthUnit.Inch"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static LengthUnit ParseLengthUnit(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            LengthUnit result;
            try
            {
                result = Length.ParseUnit(value);
            }
            catch (Exception e)
            {
                result = LengthUnit.Inch;
            }

            return result;
        }

        public static string ToStringFixed(this Length value, LengthUnit units)
        {
            switch (units)
            {
                case LengthUnit.Inch:
                    return value.Inches.ToString();
                default:
                    return value.ToString(units);
            }
        }

        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> e, Func<T, IEnumerable<T>> f)
        {
            return e.Concat(e.SelectMany(c => f(c).Flatten(f)));
        }

        public static IEnumerable<T> Expand<T>(
            this IEnumerable<T> source, Func<T, IEnumerable<T>> elementSelector)
        {
            Stack<IEnumerator<T>> stack = new Stack<IEnumerator<T>>();
            IEnumerator<T> e = source.GetEnumerator();
            try
            {
                while (true)
                {
                    while (e.MoveNext())
                    {
                        T item = e.Current;
                        yield return item;
                        IEnumerable<T> elements = elementSelector(item);
                        if (elements == null) continue;
                        stack.Push(e);
                        e = elements.GetEnumerator();
                    }
                    if (stack.Count == 0) break;
                    e.Dispose();
                    e = stack.Pop();
                }
            }
            finally
            {
                e.Dispose();
                while (stack.Count != 0) stack.Pop().Dispose();
            }
        }

        private const string Modifiers = "<>*";

        public static string GetTextWithoutModifiers(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            if (Modifiers.Any(m => m == text[0]))
            {
                return text.Substring(1, text.Length - 1);
            }

            return text;
        }

        public static char? GetModifier(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            if (Modifiers.Any(m => m == text[0]))
            {
                return text[0];
            }

            return null;
        }
    }
}
