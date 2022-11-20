namespace SaidOut.DataValidation.ParameterGuard.Extensions
{

    /// <summary>Parameter guards for collections.</summary>
    public static class CollectionExtension
    {

        /// <summary>Will throw an exception if <paramref name="paramValue"/> is null or empty.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <returns>Return <param name="paramValue"/></returns>
        /// <exception cref="ArgumentNullException">If <paramref name="paramValue"/> is <b>null</b>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="paramValue"/> is empty, i.e. does not contain any items.</exception>
        public static IEnumerable<T> CheckIsNotNullOrEmpty<T>(this IEnumerable<T>? paramValue, string paramName)
        {
            if (paramValue is null) throw new ArgumentNullException(paramName, string.Format(ExceptionMessages.CollectionCannotBeNullOrEmpty_ParamName, paramName));
            if (!paramValue.Any())
                throw new ArgumentException(string.Format(ExceptionMessages.CollectionCannotBeNullOrEmpty_ParamName, paramName), paramName);

            return paramValue;
        }


        /// <summary>Will throw an exception if <paramref name="paramValue"/> is null or empty.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramValue">The value that should be checked.</param>
        /// <param name="paramName">The name of the parameter that should be checked, i.e. the parameter name of <paramref name="paramValue"/>.</param>
        /// <returns>Return <param name="paramValue"/></returns>
        /// <exception cref="ArgumentNullException">If <paramref name="paramValue"/> is <b>null</b>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="paramValue"/> is empty, i.e. does not contain any items.</exception>
        public static ICollection<T> CheckIsNotNullOrEmpty<T>(this ICollection<T>? paramValue, string paramName)
        {
            if (paramValue is null) throw new ArgumentNullException(paramName, string.Format(ExceptionMessages.CollectionCannotBeNullOrEmpty_ParamName, paramName));
            if (paramValue.Count == 0)
                throw new ArgumentException(string.Format(ExceptionMessages.CollectionCannotBeNullOrEmpty_ParamName, paramName), paramName);

            return paramValue;
        }
    }
}