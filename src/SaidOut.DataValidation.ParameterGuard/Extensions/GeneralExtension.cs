﻿using System.Runtime.CompilerServices;

namespace SaidOut.DataValidation.ParameterGuard.Extensions
{

    public static class GeneralExtension
    {

        /// <summary>Will throw an exception if <paramref name="paramValue"/> is null.</summary>
        /// <typeparam name="T">Must be a reference type.</typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="paramValue"/> corresponds. If you omit this parameter, the name of <paramref name="paramValue"/> is used.</param>
        /// <returns>Return <paramref name="paramValue"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="paramValue"/> is <b>null</b>.</exception>
        public static T CheckIsNotNull<T>(this T? paramValue, [CallerArgumentExpression("paramValue")] string? paramName = null)
            where T : class
        {
            if (paramValue is null)
                throw new ArgumentNullException(paramName);

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> is not a defined value for the enum type <typeparamref name="TEnum"/>.</summary>
        /// <typeparam name="TEnum">Must be an enum type.</typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="paramValue"/> corresponds. If you omit this parameter, the name of <paramref name="paramValue"/> is used.</param>
        /// <returns>Return <paramref name="paramValue"/></returns>
        /// <exception cref="ArgumentException"><paramref name="paramValue"/> contain a value not defined by the enum type <typeparamref name="TEnum"/>.</exception>
        public static TEnum CheckIsDefinedInEnum<TEnum>(this TEnum paramValue, [CallerArgumentExpression("paramValue")] string? paramName = null)
            where TEnum : Enum
        {
            var enumType = typeof(TEnum);
            if (!Enum.IsDefined(enumType, paramValue))
                throw new ArgumentException(string.Format(ExceptionMessages.ParamEnumNotDefined_ParamName_Value_EnumType_DefinedEnumValues,
                    paramName,
                    paramValue,
                    enumType.FullName,
                    Enum.GetValues(enumType).OfType<TEnum>().ToDelimitedString()), paramName);

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> is not in the <paramref name="whitelist"/>.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="whitelist">Collection containing valid values.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="paramValue"/> corresponds. If you omit this parameter, the name of <paramref name="paramValue"/> is used.</param>
        /// <returns>Return <paramref name="paramValue"/></returns>
        /// <exception cref="ArgumentException"><paramref name="paramValue"/> is not in the <paramref name="whitelist"/>.</exception>
        public static T CheckIsInWhitelist<T>(this T paramValue, ICollection<T> whitelist, [CallerArgumentExpression("paramValue")] string? paramName = null)
        {
            if (!whitelist.Contains(paramValue))
                throw new ArgumentException(string.Format(ExceptionMessages.ParamValueNotValid_ParamName_Value_ValidValues, paramName, paramValue?.ToString()?.TruncateParamValue(), whitelist.ToDelimitedString()), paramName);

            return paramValue;
        }
    }
}