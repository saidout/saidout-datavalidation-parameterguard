using System;

namespace SaidOut.DataValidation.ParameterGuard.Extensions
{

    /// <summary>Contain guard extensions that check that a value is between a lower and upper bound.</summary>
    public static class ComparableExtension
    {

        /// <summary>Will throw an exception if <paramref name="paramValue"/> is outside the range [<paramref name="lowerBound"/>, <paramref name="upperBound"/>].</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="lowerBound">The lower bound of the range, i.e. the <paramref name="paramValue"/> should be equal or greater than this value.</param>
        /// <param name="upperBound">The upper bound of the range, i.e. the <paramref name="paramValue"/> should be equal or less than this value.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <returns>Return <paramref name="paramValue"/>.</returns>
        /// <exception cref="ArgumentException">If <paramref name="lowerBound"/> is greater than <paramref name="upperBound"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <paramref name="paramValue"/> is less than <paramref name="lowerBound"/> or if <paramref name="paramValue"/> is greater than <paramref name="upperBound"/>.
        /// </exception>
        public static T CheckIsInsideRange<T>(this T paramValue, T lowerBound, T upperBound, string paramName)
            where T : struct, IComparable<T>
        {
            GuardHelper.ThrowIfParamXIsGreaterThanParamY(lowerBound, nameof(lowerBound), upperBound, nameof(upperBound));

            if (paramValue.CompareTo(lowerBound) < 0 || paramValue.CompareTo(upperBound) > 0) throw new ArgumentOutOfRangeException(
                paramName, ExceptionMessages.ParamShouldBeInsideRange(paramValue, lowerBound, upperBound, paramName));

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> is equal or less than <paramref name="lowerBound"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="lowerBound">The lower bound, i.e. the value that <paramref name="paramValue"/> should be greater than.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <returns>Return <paramref name="paramValue"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="paramValue"/> is equal or less than <paramref name="lowerBound"/>.</exception>
        public static T CheckIsGreaterThan<T>(this T paramValue, T lowerBound, string paramName)
            where T : struct, IComparable<T>
        {
            if (paramValue.CompareTo(lowerBound) <= 0) throw new ArgumentOutOfRangeException(
                paramName, ExceptionMessages.ParamShouldBeGreaterThan(paramValue, lowerBound, paramName));

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> is less than <paramref name="lowerBound"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="lowerBound">The lower bound, i.e. the value that <paramref name="paramValue"/> should be equal or greater than.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <returns>Return <paramref name="paramValue"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="paramValue"/> is less than <paramref name="lowerBound"/>.</exception>
        /// <returns></returns>
        public static T CheckIsEqualOrGreaterThan<T>(this T paramValue, T lowerBound, string paramName)
            where T : struct, IComparable<T>
        {
            if (paramValue.CompareTo(lowerBound) < 0) throw new ArgumentOutOfRangeException(
                paramName, ExceptionMessages.ParamShouldBeEqualOrGreaterThan(paramValue, lowerBound, paramName));

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> is equal or greater than <paramref name="upperBound"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="upperBound">The upper bound, i.e. the value that <paramref name="paramValue"/> should be less than.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <returns>Return <paramref name="paramValue."/></returns>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="paramValue"/> is equal or greater than <paramref name="upperBound"/>.</exception>
        public static T CheckIsLessThan<T>(this T paramValue, T upperBound, string paramName)
            where T : struct, IComparable<T>
        {
            if (paramValue.CompareTo(upperBound) >= 0) throw new ArgumentOutOfRangeException(
                paramName, ExceptionMessages.ParamShouldBeLessThan(paramValue, upperBound, paramName));

            return paramValue;
        }

        /// <summary>Will throw an exception if <paramref name="paramValue"/> is greater than <paramref name="upperBound"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="upperBound">The upper bound, i.e. the value that <paramref name="paramValue"/> should be equal or less than.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <returns>Return <paramref name="paramValue"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="paramValue"/> is greater than <paramref name="upperBound"/>.</exception>
        public static T CheckIsEqualOrLessThan<T>(this T paramValue, T upperBound, string paramName)
            where T : struct, IComparable<T>
        {
            if (paramValue.CompareTo(upperBound) > 0) throw new ArgumentOutOfRangeException(
                paramName, ExceptionMessages.ParamShouldBeEqualOrLessThan(paramValue, upperBound, paramName));

            return paramValue;
        }
    }
}