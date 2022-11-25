using System.Runtime.CompilerServices;

namespace SaidOut.DataValidation.ParameterGuard
{

    public static class GuardHelper
    {

        /// <summary>Will throw an exception if <paramref name="paramX"/> is less than <paramref name="paramY"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramX">Parameter value X that should be checked that it is not less than <paramref name="paramY"/></param>
        /// <param name="paramY">Parameter value Y that <paramref name="paramX"/> should be checked against.</param>
        /// <param name="paramXName">The name of the parameter with which <paramref name="paramX"/> corresponds. If you omit this parameter, the name of <paramref name="paramX"/> is used.</param>
        /// <param name="paramYName">The name of the parameter with which <paramref name="paramY"/> corresponds. If you omit this parameter, the name of <paramref name="paramY"/> is used.</param>
        /// <exception cref="ArgumentException"><paramref name="paramX"/> is less than <paramref name="paramY"/>.</exception>
        public static void ThrowIfParamXIsLessThanParamY<T>(T paramX, T paramY,
                [CallerArgumentExpression("paramX")] string? paramXName = null, [CallerArgumentExpression("paramY")] string? paramYName = null)
            where T : struct, IComparable<T>
        {
            if (paramX.CompareTo(paramY) < 0)
                throw new ArgumentException(string.Format(ExceptionMessages.ParamXCannotBeLessThanParamY_ParamXName_ParamYName_ParamX_ParamY,
                    paramXName, paramYName, paramX, paramY), paramXName);
        }


        /// <summary>Will throw an exception if <paramref name="paramX"/> is equal or less than <paramref name="paramY"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramX">Parameter value X that should be checked that it is not equal or less than <paramref name="paramY"/></param>
        /// <param name="paramY">Parameter value Y that <paramref name="paramX"/> should be checked against.</param>
        /// <param name="paramXName">The name of the parameter with which <paramref name="paramX"/> corresponds. If you omit this parameter, the name of <paramref name="paramX"/> is used.</param>
        /// <param name="paramYName">The name of the parameter with which <paramref name="paramY"/> corresponds. If you omit this parameter, the name of <paramref name="paramY"/> is used.</param>
        /// <exception cref="ArgumentException"><paramref name="paramX"/> is equal or less than <paramref name="paramY"/>.</exception>
        public static void ThrowIfParamXIsEqualOrLessThanParamY<T>(T paramX, T paramY,
                [CallerArgumentExpression("paramX")] string? paramXName = null, [CallerArgumentExpression("paramY")] string? paramYName = null)
            where T : struct, IComparable<T>
        {
            if (paramX.CompareTo(paramY) <= 0)
                throw new ArgumentException(string.Format(ExceptionMessages.ParamXCannotBeEqualOrLessThanParamY_ParamXName_ParamYName_ParamX_ParamY,
                    paramXName, paramYName, paramX, paramY), paramXName);
        }


        /// <summary>Will throw an exception if <paramref name="paramX"/> is greater than <paramref name="paramY"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramX">Parameter value X that should be checked that it is not greater than <paramref name="paramY"/></param>
        /// <param name="paramY">Parameter value Y that <paramref name="paramX"/> should be checked against.</param>
        /// <param name="paramXName">The name of the parameter with which <paramref name="paramX"/> corresponds. If you omit this parameter, the name of <paramref name="paramX"/> is used.</param>
        /// <param name="paramYName">The name of the parameter with which <paramref name="paramY"/> corresponds. If you omit this parameter, the name of <paramref name="paramY"/> is used.</param>
        /// <exception cref="ArgumentException"><paramref name="paramX"/> is greater than <paramref name="paramY"/>.</exception>
        public static void ThrowIfParamXIsGreaterThanParamY<T>(T paramX, T paramY,
                [CallerArgumentExpression("paramX")] string? paramXName = null, [CallerArgumentExpression("paramY")] string? paramYName = null)
            where T : struct, IComparable<T>
        {
            if (paramX.CompareTo(paramY) > 0)
                throw new ArgumentException(string.Format(ExceptionMessages.ParamXCannotBeGreaterThanParamY_ParamXName_ParamYName_ParamX_ParamY,
                    paramXName, paramYName, paramX, paramY), paramXName);
        }


        /// <summary>Will throw an exception if <paramref name="paramX"/> is equal or greater than <paramref name="paramY"/>.</summary>
        /// <typeparam name="T">A value type that implement <see cref="IComparable{T}"/></typeparam>
        /// <param name="paramX">Parameter value X that should be checked that it is not equal or greater than <paramref name="paramY"/></param>
        /// <param name="paramY">Parameter value Y that <paramref name="paramX"/> should be checked against.</param>
        /// <param name="paramXName">The name of the parameter with which <paramref name="paramX"/> corresponds. If you omit this parameter, the name of <paramref name="paramX"/> is used.</param>
        /// <param name="paramYName">The name of the parameter with which <paramref name="paramY"/> corresponds. If you omit this parameter, the name of <paramref name="paramY"/> is used.</param>
        /// <exception cref="ArgumentException"><paramref name="paramX"/> is equal or greater than <paramref name="paramY"/>.</exception>
        public static void ThrowIfParamXIsEqualOrGreaterThanParamY<T>(T paramX, T paramY,
                [CallerArgumentExpression("paramX")] string? paramXName = null, [CallerArgumentExpression("paramY")] string? paramYName = null)
            where T : struct, IComparable<T>
        {
            if (paramX.CompareTo(paramY) >= 0)
                throw new ArgumentException(string.Format(ExceptionMessages.ParamXCannotBeEqualOrGreaterThanParamY_ParamXName_ParamYName_ParamX_ParamY,
                    paramXName, paramYName, paramX, paramY), paramXName);
        }
    }
}