using System.Collections.Generic;
using System.Text;

namespace SaidOut.DataValidation.ParameterGuard
{

    internal static class HelperExtensions
    {
        private const string TruncateSymbol = "...";
        private const int TruncateMaxLength = 250 - 3; // -3 truncate symbol length


        public static string TruncateParamValue(this string input)
        {
            if (input.Length > TruncateMaxLength)
                return input.Substring(0, TruncateMaxLength) + TruncateSymbol;

            return input;
        }


        public static string ToDelimitatedString<T>(this IEnumerable<T> values)
        {
            var sb = new StringBuilder();
            using (var enumerator = values.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    sb.Append(enumerator.Current);
                }

                var hasNextValue = enumerator.MoveNext();
                while (hasNextValue)
                {
                    var current = enumerator.Current;
                    hasNextValue = enumerator.MoveNext();
                    if (!hasNextValue)
                    {
                        sb.Append(" and " + current);
                        break;
                    }

                    sb.Append(", " + current);
                }
            }

            return sb.ToString();
        }
    }
 }