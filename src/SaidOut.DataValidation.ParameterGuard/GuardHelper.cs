using System;

namespace SaidOut.DataValidation.ParameterGuard
{

    /// <summary>Contain guard methods that compare two values to each other.</summary>
    public static class GuardHelper
    {

        /// <summary>Will throw an exception if <paramref name="paramX"/> is less than <paramref name="paramY"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramX">Parameter value X that should be checked that it is not less than <paramref name="paramY"/></param>
        /// <param name="paramY">Parameter value Y that <paramref name="paramX"/> should be checked against.</param>
        /// <param name="paramXName">The name of parameter <paramref name="paramX"/>.</param>
        /// <param name="paramYName">The name of parameter <paramref name="paramY"/>.</param>
        /// <exception cref="ArgumentException">If <paramref name="paramX"/> is less than <paramref name="paramY"/>.</exception>
        public static void ThrowIfParamXIsLessThanParamY<T>(T paramX, string paramXName, T paramY, string paramYName)
            where T : struct, IComparable<T>
        {
            if (paramX.CompareTo(paramY) < 0) throw new ArgumentException(
                ExceptionMessages.ParamXCannotBeLessThanParamY(paramX, paramXName, paramY, paramYName), paramXName);
        }


        /// <summary>Will throw an exception if <paramref name="paramX"/> is equal or less than <paramref name="paramY"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramX">Parameter value X that should be checked that it is not equal or less than <paramref name="paramY"/></param>
        /// <param name="paramY">Parameter value Y that <paramref name="paramX"/> should be checked against.</param>
        /// <param name="paramXName">The name of parameter <paramref name="paramX"/>.</param>
        /// <param name="paramYName">The name of parameter <paramref name="paramY"/>.</param>
        /// <exception cref="ArgumentException">If <paramref name="paramX"/> is equal or less than <paramref name="paramY"/>.</exception>
        public static void ThrowIfParamXIsEqualOrLessThanParamY<T>(T paramX, string paramXName, T paramY, string paramYName)
            where T : struct, IComparable<T>
        {
            if (paramX.CompareTo(paramY) <= 0) throw new ArgumentException(
                ExceptionMessages.ParamXCannotBeEqualOrLessThanParamY(paramX, paramXName, paramY, paramYName), paramXName);
        }


        /// <summary>Will throw an exception if <paramref name="paramX"/> is greater than <paramref name="paramY"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramX">Parameter value X that should be checked that it is not greater than <paramref name="paramY"/></param>
        /// <param name="paramY">Parameter value Y that <paramref name="paramX"/> should be checked against.</param>
        /// <param name="paramXName">The name of parameter <paramref name="paramX"/>.</param>
        /// <param name="paramYName">The name of parameter <paramref name="paramY"/>.</param>
        /// <exception cref="ArgumentException">If <paramref name="paramX"/> is greater than <paramref name="paramY"/>.</exception>
        public static void ThrowIfParamXIsGreaterThanParamY<T>(T paramX, string paramXName, T paramY, string paramYName)
            where T : struct, IComparable<T>
        {
            if (paramX.CompareTo(paramY) > 0) throw new ArgumentException(
                ExceptionMessages.ParamXCannotBeGreaterThanParamY(paramX, paramXName, paramY, paramYName), paramXName);
        }


        /// <summary>Will throw an exception if <paramref name="paramX"/> is equal or greater than <paramref name="paramY"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramX">Parameter value X that should be checked that it is not equal or greater than <paramref name="paramY"/></param>
        /// <param name="paramY">Parameter value Y that <paramref name="paramX"/> should be checked against.</param>
        /// <param name="paramXName">The name of parameter <paramref name="paramX"/>.</param>
        /// <param name="paramYName">The name of parameter <paramref name="paramY"/>.</param>
        /// <exception cref="ArgumentException">If <paramref name="paramX"/> is equal or greater than <paramref name="paramY"/>.</exception>
        public static void ThrowIfParamXIsEqualOrGreaterThanParamY<T>(T paramX, string paramXName, T paramY, string paramYName)
            where T : struct, IComparable<T>
        {
            if (paramX.CompareTo(paramY) >= 0) throw new ArgumentException(
                ExceptionMessages.ParamXCannotBeEqualOrGreaterThanParamY(paramX, paramXName, paramY, paramYName), paramXName);
        }
    }
}