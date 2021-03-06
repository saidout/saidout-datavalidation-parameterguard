﻿using System;
using System.Text.RegularExpressions;

namespace SaidOut.DataValidation.ParameterGuard.Extensions
{

    /// <summary>Contain guard extensions for <see cref="string"/>.</summary>
    public static class StringExtension
    {

        /// <summary>Will throw an exception if <paramref name="paramValue"/> is null or a blank string.</summary>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="paramValue"/> is <b>null</b>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="paramValue"/> is a blank string, i.e. is empty or only contains white spaces.</exception>
        public static string CheckIsNotNullOrBlank(this string paramValue, string paramName)
        {
            if (paramValue == null) throw new ArgumentNullException(paramName);
            if (string.IsNullOrWhiteSpace(paramValue)) throw new ArgumentException(
                ExceptionMessages.StringParamCannotBeBlank(paramName), paramName);

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> does not match the <paramref name="regexPattern"/>.</summary>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="regexPattern">The regex pattern that <paramref name="paramValue"/> should match.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <returns>Return <paramref name="paramValue"/>.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="paramValue"/> is <b>null</b>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="paramValue"/> does not match the <paramref name="regexPattern"/>.</exception>
        public static string CheckMatchRegexPattern(this string paramValue, string regexPattern, string paramName)
        {
            if (paramValue == null) throw new ArgumentNullException(paramName);
            if (!Regex.IsMatch(paramValue, regexPattern)) throw new ArgumentException(
                ExceptionMessages.ParamDoesNotMatchRegexPattern(paramValue, regexPattern, paramName), paramName);

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> is not an hex string representing a byte array with number of bytes in the range [<paramref name="minByteSize"/>, <paramref name="maxByteSize"/>].</summary>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <param name="minByteSize">Minimum number of bytes the hex string should represent.</param>
        /// <param name="maxByteSize">Maximum number of bytes the hex string should represent.</param>
        /// <returns>Return <paramref name="paramValue"/></returns>
        /// <exception cref="ArgumentException">If <paramref name="paramValue"/> does not contain a hex string or if the number of bytes the hex string represent is not inside the range of [<paramref name="minByteSize"/>, <paramref name="maxByteSize"/>].</exception>
        public static string CheckIsHexString(this string paramValue, string paramName, int minByteSize = 0, int maxByteSize = int.MaxValue)
        {
            minByteSize.CheckIsEqualOrGreaterThan(0, nameof(minByteSize));
            GuardHelper.ThrowIfParamXIsGreaterThanParamY(minByteSize, nameof(minByteSize), maxByteSize, nameof(maxByteSize));
            const string validHexStringRegex = "^([0-9a-fA-F][0-9a-fA-F])*$";

            if (paramValue == null) throw new ArgumentNullException(paramName);
            var valueToCheck = paramValue.StartsWith("0x")
                ? paramValue.Substring(2)
                : paramValue;

            if (valueToCheck.Length % 2 != 0 || !Regex.IsMatch(valueToCheck, validHexStringRegex))
                throw new ArgumentException(ExceptionMessages.ParamIsNotHexString(paramValue, paramName), paramName);

            var bytesInValue = valueToCheck.Length / 2;
            if (bytesInValue >= minByteSize && bytesInValue <= maxByteSize) return paramValue;
            
            if (maxByteSize == int.MaxValue)
                throw new ArgumentException(ExceptionMessages.ParamHexStringBytesIsLessThanMinByteSize(paramValue, bytesInValue, paramName, minByteSize), paramName);
            if (minByteSize == 0)
                throw new ArgumentException(ExceptionMessages.ParamHexStringBytesIsGreaterThanMaxByteSize(paramValue, bytesInValue, paramName, maxByteSize), paramName);

            throw new ArgumentException(ExceptionMessages.ParamHexStringBytesIsNotInsideValidRange(paramValue, bytesInValue, paramName, minByteSize, maxByteSize), paramName);
        }
    }
}