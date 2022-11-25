using System.Runtime.CompilerServices;

namespace SaidOut.DataValidation.ParameterGuard.Extensions
{

    public static class ComparableExtension
    {

        /// <summary>Will throw an exception if <paramref name="paramValue"/> is outside the range [<paramref name="lowerBound"/>, <paramref name="upperBound"/>].</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="lowerBound">The lower bound of the range, i.e. the <paramref name="paramValue"/> should be equal or greater than this value.</param>
        /// <param name="upperBound">The upper bound of the range, i.e. the <paramref name="paramValue"/> should be equal or less than this value.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="paramValue"/> corresponds. If you omit this parameter, the name of <paramref name="paramValue"/> is used.</param>
        /// <returns>Return <paramref name="paramValue"/></returns>
        /// <exception cref="ArgumentException"><param name="lowerBound"/> is greater than <param name="upperBound"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="paramValue"/> is less than <paramref name="lowerBound"/> or if <paramref name="paramValue"/> is greater than <paramref name="upperBound"/>.
        /// </exception>
        public static T CheckIsInsideRange<T>(this T paramValue, T lowerBound, T upperBound, [CallerArgumentExpression("paramValue")] string? paramName = null)
            where T : struct, IComparable<T>
        {
            GuardHelper.ThrowIfParamXIsGreaterThanParamY(lowerBound, upperBound);
            if (paramValue.CompareTo(lowerBound) < 0 || paramValue.CompareTo(upperBound) > 0)
                throw new ArgumentOutOfRangeException(paramName, string.Format(ExceptionMessages.ParamShouldBeInsideRange_ParamName_LowerBound_UpperBound_Value, paramName, lowerBound, upperBound, paramValue));

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> is equal or less than <paramref name="lowerBound"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="lowerBound">The lower bound, i.e. the value that <paramref name="paramValue"/> should be greater than.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="paramValue"/> corresponds. If you omit this parameter, the name of <paramref name="paramValue"/> is used.</param
        /// <returns>Return <paramref name="paramValue"/></returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="paramValue"/> is equal or less than <paramref name="lowerBound"/>.</exception>
        public static T CheckIsGreaterThan<T>(this T paramValue, T lowerBound, [CallerArgumentExpression("paramValue")] string? paramName = null)
            where T : struct, IComparable<T>
        {
            if (paramValue.CompareTo(lowerBound) <= 0)
                throw new ArgumentOutOfRangeException(paramName, string.Format(ExceptionMessages.ParamShouldBeGreaterThan_ParamName_LowerBound_Value, paramName, lowerBound, paramValue));

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> is less than <paramref name="lowerBound"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="lowerBound">The lower bound, i.e. the value that <paramref name="paramValue"/> should be equal or greater than.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="paramValue"/> corresponds. If you omit this parameter, the name of <paramref name="paramValue"/> is used.</param>
        /// <returns>Return <paramref name="paramValue"/></returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="paramValue"/> is less than <paramref name="lowerBound"/>.</exception>
        /// <returns></returns>
        public static T CheckIsEqualOrGreaterThan<T>(this T paramValue, T lowerBound, [CallerArgumentExpression("paramValue")] string? paramName = null)
            where T : struct, IComparable<T>
        {
            if (paramValue.CompareTo(lowerBound) < 0)
                throw new ArgumentOutOfRangeException(paramName, string.Format(ExceptionMessages.ParamShouldBeEqualOrGreaterThan_ParamName_LowerBound_Value, paramName, lowerBound, paramValue));

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> is equal or greater than <paramref name="upperBound"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="upperBound">The upper bound, i.e. the value that <paramref name="paramValue"/> should be less than.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="paramValue"/> corresponds. If you omit this parameter, the name of <paramref name="paramValue"/> is used.</param>
        /// <returns>Return <paramref name="paramValue"/></returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="paramValue"/> is equal or greater than <paramref name="upperBound"/>.</exception>
        public static T CheckIsLessThan<T>(this T paramValue, T upperBound, [CallerArgumentExpression("paramValue")] string? paramName = null)
            where T : struct, IComparable<T>
        {
            if (paramValue.CompareTo(upperBound) >= 0)
                throw new ArgumentOutOfRangeException(paramName, string.Format(ExceptionMessages.ParamShouldBeLessThan_ParamName_UpperBound_Value, paramName, upperBound, paramValue));

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> is greater than <paramref name="upperBound"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="upperBound">The upper bound, i.e. the value that <paramref name="paramValue"/> should be equal or less than.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="paramValue"/> corresponds. If you omit this parameter, the name of <paramref name="paramValue"/> is used.</param>

        /// <returns>Return <paramref name="paramValue"/></returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="paramValue"/> is greater than <paramref name="upperBound"/>.</exception>
        public static T CheckIsEqualOrLessThan<T>(this T paramValue, T upperBound, [CallerArgumentExpression("paramValue")] string? paramName = null)
            where T : struct, IComparable<T>
        {
            if (paramValue.CompareTo(upperBound) > 0)
                throw new ArgumentOutOfRangeException(paramName, string.Format(ExceptionMessages.ParamShouldBeEqualOrLessThan_ParamName_UpperBound_Value, paramName, upperBound, paramValue));

            return paramValue;
        }
    }
}