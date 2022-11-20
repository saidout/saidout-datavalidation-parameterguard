using System;
using System.Text.RegularExpressions;

namespace SaidOut.DataValidation.ParameterGuard.Extensions
{

    public static class StringExtension
    {

        /// <summary>Will throw an exception if <paramref name="paramValue"/> is null or a blank string.</summary>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="paramValue"/> is <b>null</b>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="paramValue"/> is a blank string, i.e. is empty or only contains white spaces.</exception>
        public static string CheckIsNotNullOrBlank(this string? paramValue, string paramName)
        {
            if (paramValue is null) throw new ArgumentNullException(paramName);
            if (string.IsNullOrWhiteSpace(paramValue))
                throw new ArgumentException(string.Format(ExceptionMessages.StringParamCannotBeBlank_ParamName, paramName), paramName);

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> does not match the <paramref name="regexPattern"/>.</summary>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="regexPattern">The regex pattern that <paramref name="paramValue"/> should match.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <returns>Return <param name="paramValue"/></returns>
        /// <exception cref="ArgumentNullException">If <paramref name="paramValue"/> is <b>null</b>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="paramValue"/> does not match the <paramref name="regexPattern"/>.</exception>
        public static string CheckMatchRegexPattern(this string? paramValue, string regexPattern, string paramName)
        {
            if (paramValue is null) throw new ArgumentNullException(paramName);
            if (!Regex.IsMatch(paramValue, regexPattern))
                throw new ArgumentException(string.Format(ExceptionMessages.ParamDoesNotMatchRegExPattern_ParamName_RegexPattern_Value, paramName, regexPattern, paramValue.TruncateParamValue()), paramName);

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> is not an hex string representing a byte array with number of bytes in the range [<paramref name="minByteSize"/>, <paramref name="maxByteSize"/>].</summary>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <param name="minByteSize">Minimum number of bytes the hex string should represent.</param>
        /// <param name="maxByteSize">Maximum number of bytes the hex string should represent.</param>
        /// <returns>Return <param name="paramValue"/></returns>
        /// <exception cref="ArgumentException">If <paramref name="paramValue"/> does not contain a hex string or if the number of bytes the hex string represent is not inside the range of [<paramref name="minByteSize"/>, <paramref name="maxByteSize"/>].</exception>
        public static string CheckIsHexString(this string? paramValue, string paramName, int minByteSize = 0, int maxByteSize = int.MaxValue)
        {
            minByteSize.CheckIsEqualOrGreaterThan(0, nameof(minByteSize));
            GuardHelper.ThrowIfParamXIsGreaterThanParamY(minByteSize, nameof(minByteSize), maxByteSize, nameof(maxByteSize));
            const string validHexStringRegex = "^([0-9a-fA-F][0-9a-fA-F])*$";

            if (paramValue is null) throw new ArgumentNullException(paramName);
            var valueToCheck = paramValue.StartsWith("0x")
                ? paramValue.Substring(2)
                : paramValue;

            if (valueToCheck.Length % 2 != 0 || !Regex.IsMatch(valueToCheck, validHexStringRegex))
                throw new ArgumentException(string.Format(ExceptionMessages.ParamIsNotHexString_ParamName_Value, paramName, HexValueToExString(paramValue)), paramName);

            var bytesInValue = valueToCheck.Length / 2;

            if (bytesInValue < minByteSize && maxByteSize == int.MaxValue)
                throw new ArgumentException(string.Format(ExceptionMessages.ParamHexStringBytesIsLessThanMinByteSize_ParamName_Value_BytesInValue_MinBytes, paramName, HexValueToExString(paramValue), bytesInValue, minByteSize), paramName);

            if (bytesInValue > maxByteSize && minByteSize == 0)
                throw new ArgumentException(string.Format(ExceptionMessages.ParamHexStringBytesIsGreaterThanMaxByteSize_ParamName_Value_BytesInValue_MaxBytes, paramName, HexValueToExString(paramValue), bytesInValue, maxByteSize), paramName);

            if (bytesInValue < minByteSize || bytesInValue > maxByteSize)
                throw new ArgumentException(string.Format(ExceptionMessages.ParamHexStringBytesIsNotInsideValidRange_ParamName_Value_BytesInValue_MinBytes_MaxBytes, paramName, HexValueToExString(paramValue), bytesInValue, minByteSize, maxByteSize), paramName);

            return paramValue;
        }


        private static string HexValueToExString(string val)
        {
            if (string.IsNullOrEmpty(val)) return "<EMPTY>";
            return val.TruncateParamValue();
        }
    }
}