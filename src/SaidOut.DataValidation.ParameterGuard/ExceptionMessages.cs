namespace SaidOut.DataValidation.ParameterGuard
{

    internal static class ExceptionMessages
    {

        /// <summary>{0} can't be less than {1}. Value of {0} was '{2}' and value of {1} was '{3}'.</summary>
        public const string ParamXCannotBeLessThanParamY_ParamXName_ParamYName_ParamX_ParamY = "{0} can't be less than {1}. Value of {0} was '{2}' and value of {1} was '{3}'.";

        /// <summary>{0} can't be equal or less than {1}. Value of {0} was '{2}' and value of {1} was '{3}'.</summary>
        public const string ParamXCannotBeEqualOrLessThanParamY_ParamXName_ParamYName_ParamX_ParamY = "{0} can't be equal or less than {1}. Value of {0} was '{2}' and value of {1} was '{3}'.";

        /// <summary>{0} can't be greater than {1}. Value of {0} was '{2}' and value of {1} was '{3}'.</summary>
        public const string ParamXCannotBeGreaterThanParamY_ParamXName_ParamYName_ParamX_ParamY = "{0} can't be greater than {1}. Value of {0} was '{2}' and value of {1} was '{3}'.";

        /// <summary>{0} can't be equal or greater than {1}. Value of {0} was '{2}' and value of {1} was '{3}'.</summary>
        public const string ParamXCannotBeEqualOrGreaterThanParamY_ParamXName_ParamYName_ParamX_ParamY = "{0} can't be equal or greater than {1}. Value of {0} was '{2}' and value of {1} was '{3}'.";



        /// <summary>Collection {0} can't be empty.</summary>
        public const string CollectionCannotBeNullOrEmpty_ParamName = "Collection {0} can't be null or empty.";



        /// <summary>{0} should be inside range [{1}, {2}] but it's value was '{3}'.</summary>
        public const string ParamShouldBeInsideRange_ParamName_LowerBound_UpperBound_Value = "{0} should be inside range [{1}, {2}] but it's value was '{3}'.";

        /// <summary>"{0} should be greater than {1} but it's value was '{2}'.</summary>
        public const string ParamShouldBeGreaterThan_ParamName_LowerBound_Value = "{0} should be greater than {1} but it's value was '{2}'.";

        /// <summary>{0} should be equal or greater than {1} but it's value was '{2}'.</summary>
        public const string ParamShouldBeEqualOrGreaterThan_ParamName_LowerBound_Value = "{0} should be equal or greater than {1} but it's value was '{2}'.";

        /// <summary>{0} should be less than {1} but it's value was '{2}'.</summary>
        public const string ParamShouldBeLessThan_ParamName_UpperBound_Value = "{0} should be less than {1} but it's value was '{2}'.";

        /// <summary>{0} should be equal or less than {1} but it's value was '{2}'.</summary>
        public const string ParamShouldBeEqualOrLessThan_ParamName_UpperBound_Value = "{0} should be equal or less than {1} but it's value was '{2}'.";



        /// <summary>{0} value '{1}' is not a deifned enum value of type {2}. Defined values are: {3}</summary>
        public const string ParamEnumNotDefined_ParamName_Value_EnumType_DefinedEnumValues = "{0} value '{1}' is not a deifned enum value of type {2}. Defined values are: {3}";

        /// <summary>{0} value of '{1}' is not a valid value. Valid values are: {2}.</summary>
        public const string ParamValueNotValid_ParamName_Value_ValidValues = "{0} value of '{1}' is not a valid value. Valid values are: {2}.";

        /// <summary>{0} parameter can't be blank string.</summary>
        public const string StringParamCannotBeBlank_ParamName = "{0} can't be blank string.";



        /// <summary>{0} does not match regex pattern {1} its value was {2}.</summary>
        public const string ParamDoesNotMatchRegExPattern_ParamName_RegexPattern_Value = "{0} does not match regex pattern {1} it's value was '{2}'.";

        /// <summary>{0} does not contain a valid hex string it's value was '{1}'.</summary>
        public const string ParamIsNotHexString_ParamName_Value = "{0} does not contain a valid hex string it's value was '{1}'.";

        /// <summary>{0} hex string value {1} contains {2} bytes which is not inside valid range of [{3}, {4}].</summary>
        public const string ParamHexStringBytesIsNotInsideValidRange_ParamName_Value_BytesInValue_MinBytes_MaxBytes = "{0} hex string value {1} contains {2} bytes which is not inside valid range of [{3}, {4}].";

        /// <summary>{0} hex string value {1} contains {2} bytes which is less than min byte size requirement of {3}.</summary>
        public const string ParamHexStringBytesIsLessThanMinByteSize_ParamName_Value_BytesInValue_MinBytes = "{0} hex string value {1} contains {2} bytes which is less than min byte size requirement of {3}.";

        /// <summary>{0} hex string value {1} contains {2} bytes which is greater than max byte size requirement of {3}.</summary>
        public const string ParamHexStringBytesIsGreaterThanMaxByteSize_ParamName_Value_BytesInValue_MaxBytes = "{0} hex string value {1} contains {2} bytes which is greater than max byte size requirement of {3}.";
    }
}