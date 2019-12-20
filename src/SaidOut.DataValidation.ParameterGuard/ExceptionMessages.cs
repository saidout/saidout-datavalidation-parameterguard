using System;
using System.Collections.Generic;
using System.Linq;

namespace SaidOut.DataValidation.ParameterGuard
{

    internal static class ExceptionMessages
    {

        /// <summary>{paramXName} can't be less than {paramYName}. Value of {paramXName} was '{paramX}' and value of {paramYName} was '{paramY}'.</summary>
        public static string ParamXCannotBeLessThanParamY<T>(T paramX, string paramXName, T paramY, string paramYName) where T : struct, IComparable<T> =>
            $"{paramXName} can't be less than {paramYName}. Value of {paramXName} was '{paramX}' and value of {paramYName} was '{paramY}'.";

        /// <summary>{paramXName} can't be equal or less than {paramYName}. Value of {paramXName} was '{paramX}' and value of {paramYName} was '{paramY}'.</summary>
        public static string ParamXCannotBeEqualOrLessThanParamY<T>(T paramX, string paramXName, T paramY, string paramYName) where T : struct, IComparable<T> =>
            $"{paramXName} can't be equal or less than {paramYName}. Value of {paramXName} was '{paramX}' and value of {paramYName} was '{paramY}'.";

        /// <summary>{paramXName} can't be greater than {paramYName}. Value of {paramXName} was '{paramX}' and value of {paramYName} was '{paramY}'.</summary>
        public static string ParamXCannotBeGreaterThanParamY<T>(T paramX, string paramXName, T paramY, string paramYName) where T : struct, IComparable<T> =>
            $"{paramXName} can't be greater than {paramYName}. Value of {paramXName} was '{paramX}' and value of {paramYName} was '{paramY}'.";

        /// <summary>{paramXName} can't be equal or greater than {paramYName}. Value of {paramXName} was '{paramX}' and value of {paramYName} was '{paramY}'.</summary>
        public static string ParamXCannotBeEqualOrGreaterThanParamY<T>(T paramX, string paramXName, T paramY, string paramYName) where T : struct, IComparable<T> =>
            $"{paramXName} can't be equal or greater than {paramYName}. Value of {paramXName} was '{paramX}' and value of {paramYName} was '{paramY}'.";



        /// <summary>Collection {paramName} can't be null or empty.</summary>
        public static string CollectionCannotBeNullOrEmpty(string paramName) => $"Collection {paramName} can't be null or empty.";



        /// <summary>{paramName} should be inside range [{lowerBound}, {upperBound}] but it's value was '{paramValue}'.</summary>
        public static string ParamShouldBeInsideRange<T>(T paramValue, T lowerBound, T upperBound, string paramName) where T : struct, IComparable<T> =>
            $"{paramName} should be inside range [{lowerBound}, {upperBound}] but it's value was '{paramValue}'.";

        /// <summary>{paramName} should be greater than {lowerBound} but it's value was '{paramValue}'.</summary>
        public static string ParamShouldBeGreaterThan<T>(T paramValue, T lowerBound, string paramName) where T : struct, IComparable<T> =>
            $"{paramName} should be greater than {lowerBound} but it's value was '{paramValue}'.";

        /// <summary>{paramName} should be equal or greater than {lowerBound} but it's value was '{paramValue}'.</summary>
        public static string ParamShouldBeEqualOrGreaterThan<T>(T paramValue, T lowerBound, string paramName) where T : struct, IComparable<T> =>
            $"{paramName} should be equal or greater than {lowerBound} but it's value was '{paramValue}'.";

        /// <summary>{paramName} should be less than {upperBound} but it's value was '{paramValue}'.</summary>
        public static string ParamShouldBeLessThan<T>(T paramValue, T upperBound, string paramName) where T : struct, IComparable<T> =>
            $"{paramName} should be less than {upperBound} but it's value was '{paramValue}'.";

        /// <summary>{0} should be equal or less than {1} but it's value was '{2}'.</summary>
        public static string ParamShouldBeEqualOrLessThan<T>(T paramValue, T upperBound, string paramName) where T : struct, IComparable<T> =>
            $"{paramName} should be equal or less than {upperBound} but it's value was '{paramValue}'.";



        /// <summary>"{paramName} value '{paramValue}' is not a defined enum value of type |EnumFullname|. Defined values are: |DefinedEnumValues|</summary>
        public static string ParamEnumNotDefined<TEnum>(TEnum paramValue, string paramName) where TEnum : struct, IComparable, IFormattable, IConvertible =>
            $"{paramName} value '{paramValue}' is not a defined enum value of type {typeof(TEnum).FullName}. Defined values are: {Enum.GetValues(typeof(TEnum)).OfType<TEnum>().ToDelimitedString()}";

        /// <summary>{paramName} value of '{paramValue}' is not a valid value. Valid values are: {whitelist}.</summary>
        public static string ParamValueNotInWhitelist<T>(T paramValue, ICollection<T> whitelist, string paramName) =>
            $"{paramName} value of '{paramValue?.ToString().TruncateParamValue()}' is not a valid value. Valid values are: {whitelist.ToDelimitedString()}.";



        /// <summary>{paramName} can't be blank string.</summary>
        public static string StringParamCannotBeBlank(string paramName) => $"{paramName} can't be blank string.";

        /// <summary>{paramName} does not match regex pattern {regexPattern} it's value was '{paramValue}'.</summary>
        public static string ParamDoesNotMatchRegexPattern(string paramValue, string regexPattern, string paramName) =>
            $"{paramName} does not match regex pattern {regexPattern} it's value was '{paramValue?.TruncateParamValue()}'.";

        //string paramValue, string paramName, int minByteSize = 0, int maxByteSize = int.MaxValue

        /// <summary>{paramName} does not contain a valid hex string it's value was '{paramValue}'.</summary>
        public static string ParamIsNotHexString(string paramValue, string paramName) =>
            $"{paramName} does not contain a valid hex string it's value was '{paramValue?.TruncateParamValue()}'.";

        /// <summary>{paramName} hex string value '{paramValue}' contains {bytesInValue} bytes which is not inside valid range of [{minByteSize}, {maxByteSize}].</summary>
        public static string ParamHexStringBytesIsNotInsideValidRange(string paramValue, int bytesInValue, string paramName, int minByteSize, int maxByteSize) =>
            $"{paramName} hex string value '{paramValue?.TruncateParamValue()}' contains {bytesInValue} bytes which is not inside valid range of [{minByteSize}, {maxByteSize}].";

        /// <summary>{paramName} hex string value '{paramValue.TruncateParamValue()}' contains {bytesInValue} bytes which is less than min byte size requirement of {minByteSize}.</summary>
        public static string ParamHexStringBytesIsLessThanMinByteSize(string paramValue, int bytesInValue, string paramName, int minByteSize) =>
            $"{paramName} hex string value '{paramValue?.TruncateParamValue()}' contains {bytesInValue} bytes which is less than min byte size requirement of {minByteSize}.";

        /// <summary>{paramName} hex string value '{paramValue}' contains {bytesInValue} bytes which is greater than max byte size requirement of {maxByteSize}.</summary>
        public static string ParamHexStringBytesIsGreaterThanMaxByteSize(string paramValue, int bytesInValue, string paramName, int maxByteSize) =>
            $"{paramName} hex string value '{paramValue?.TruncateParamValue()}' contains {bytesInValue} bytes which is greater than max byte size requirement of {maxByteSize}.";
    }
}