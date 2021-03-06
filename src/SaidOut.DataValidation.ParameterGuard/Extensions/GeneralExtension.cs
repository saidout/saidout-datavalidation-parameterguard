﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SaidOut.DataValidation.ParameterGuard.Extensions
{

    /// <summary>Contain guard extensions for generic check like: is not null, is defined enum value, etc.</summary>
    public static class GeneralExtension
    {

        /// <summary>Will throw an exception if <paramref name="paramValue"/> is null.</summary>
        /// <typeparam name="T">Must be a reference type.</typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <returns>Return <paramref name="paramValue"/>.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="paramValue"/> is <b>null</b>.</exception>
        public static T CheckIsNotNull<T>(this T paramValue, string paramName)
            where T : class
        {
            if (paramValue == null)
                throw new ArgumentNullException(paramName);

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> is not a defined value for the enum type <typeparamref name="TEnum"/>.</summary>
        /// <typeparam name="TEnum">Must be an enum type.</typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <returns>Return <paramref name="paramValue"/>.</returns>
        /// <exception cref="ArgumentException">If <paramref name="paramValue"/> contain a value not defined by the enum type <typeparamref name="TEnum"/>.</exception>
        public static TEnum CheckIsDefinedInEnum<TEnum>(this TEnum paramValue, string paramName)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var enumType = typeof(TEnum);
            if (!Enum.IsDefined(enumType, paramValue)) throw new ArgumentException(
                ExceptionMessages.ParamEnumNotDefined(paramValue, paramName), paramName);

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> is not in the <paramref name="whitelist"/>.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="whitelist">Collection containing valid values.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <returns>Return <paramref name="paramValue"/>.</returns>
        /// <exception cref="ArgumentException">If <paramref name="paramValue"/> is not in the <paramref name="whitelist"/>.</exception>
        public static T CheckIsInWhitelist<T>(this T paramValue, ICollection<T> whitelist, string paramName)
        {
            if (!whitelist.Contains(paramValue)) throw new ArgumentException(
                ExceptionMessages.ParamValueNotInWhitelist(paramValue, whitelist, paramName), paramName);

            return paramValue;
        }
    }
}