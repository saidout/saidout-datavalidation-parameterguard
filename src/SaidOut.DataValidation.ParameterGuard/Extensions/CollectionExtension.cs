﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SaidOut.DataValidation.ParameterGuard.Extensions
{

    /// <summary>Contain guard extensions for collections, i.e. type derived from <see cref="IEnumerable{T}"/>.</summary>
    public static class CollectionExtension
    {

        /// <summary>Will throw an exception if <paramref name="paramValue"/> is null or empty.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <returns>Return <paramref name="paramValue"/>.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="paramValue"/> is <b>null</b>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="paramValue"/> is empty, i.e. does not contain any items.</exception>
        public static IEnumerable<T> CheckIsNotNullOrEmpty<T>(this IEnumerable<T> paramValue, string paramName)
        {
            if (paramValue == null) throw new ArgumentNullException(paramName, ExceptionMessages.CollectionCannotBeNullOrEmpty(paramName));
            if (!paramValue.Any()) throw new ArgumentException(ExceptionMessages.CollectionCannotBeNullOrEmpty(paramName), paramName);

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> is null or empty.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <returns>Return <paramref name="paramValue"/>.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="paramValue"/> is <b>null</b>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="paramValue"/> is empty, i.e. does not contain any items.</exception>
        public static ICollection<T> CheckIsNotNullOrEmpty<T>(this ICollection<T> paramValue, string paramName)
        {
            if (paramValue == null) throw new ArgumentNullException(paramName, ExceptionMessages.CollectionCannotBeNullOrEmpty(paramName));
            if (paramValue.Count == 0) throw new ArgumentException(ExceptionMessages.CollectionCannotBeNullOrEmpty(paramName), paramName);

            return paramValue;
        }
    }
}