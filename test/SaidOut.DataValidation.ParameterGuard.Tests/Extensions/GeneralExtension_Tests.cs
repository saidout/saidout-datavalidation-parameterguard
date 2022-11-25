using NUnit.Framework;
using SaidOut.DataValidation.ParameterGuard.Extensions;

namespace SaidOut.DataValidation.ParameterGuard.Tests.Extensions
{

    public enum TestEnum
    {
        MinusHundred = -100,
        Zero = 0,
        Hundred = 100
    }


    public class GeneralExtension_Tests
    {
        private const string DefaultParamName = "paramName";


        #region CheckIsNotNull

        #region CheckIsNotNull with paramName
        [TestCase("paramA")]
        [TestCase("paramB")]
        public void CheckIsNotNullWithParamName_ValueIsNull_ThrowsArgumentNullException(string paramName)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ((object?)null).CheckIsNotNull(paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
        }


        [TestCase("paramA")]
        [TestCase("paramB")]
        public void CheckIsNotNullWithParamName_ValueIsNotNull_ReturnParamValue(string paramName)
        {
            var obj = new object();

            var actual = obj.CheckIsNotNull(paramName);

            Assert.That(actual, Is.EqualTo(obj));
        }
        #endregion

        #region CheckIsNotNull without paramName
        [Test]
        public void CheckIsNotNull_ValueIsNull_ThrowsArgumentNullException()
        {
            var paramValueTest = (object?) null;

            var ex = Assert.Throws<ArgumentNullException>(() => paramValueTest.CheckIsNotNull());
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(paramValueTest)), nameof(ex.ParamName));
        }


        [Test]
        public void CheckIsNotNull_ValueIsNotNull_ReturnParamValue()
        {
            var obj = new object();

            var actual = obj.CheckIsNotNull();

            Assert.That(actual, Is.EqualTo(obj));
        }
        #endregion

        #endregion


        #region CheckIsDefinedInEnum

        #region CheckIsDefinedInEnum with paramName
        [TestCase(5, "paramA")]
        [TestCase(25, "paramB")]
        public void CheckIsDefinedInEnumWithParamName_EnumValueNotDefined_ThrowsArgumentException(int valueNotDefined, string paramName)
        {
            TestEnum enumValueNotDefined = (TestEnum)valueNotDefined;

            var ex = Assert.Throws<ArgumentException>(() => enumValueNotDefined.CheckIsDefinedInEnum(paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain($"{enumValueNotDefined}"), nameof(ex.Message));
        }


        [TestCase(TestEnum.MinusHundred, "paramA")]
        [TestCase(TestEnum.Zero, "paramB")]
        [TestCase(TestEnum.Hundred, "paramC")]
        public void CheckIsDefinedInEnumWithParamName_EnumValueDefined_ReturnParamValue(TestEnum enumValueDefined, string paramName)
        {
            var actual = enumValueDefined.CheckIsDefinedInEnum(paramName);

            Assert.That(actual, Is.EqualTo(enumValueDefined));
        }
        #endregion

        #region CheckIsDefinedInEnum without paramName
        [TestCase(5)]
        [TestCase(25)]
        public void CheckIsDefinedInEnum_EnumValueNotDefined_ThrowsArgumentException(int valueNotDefined)
        {
            var enumValueNotDefined = (TestEnum)valueNotDefined;

            var ex = Assert.Throws<ArgumentException>(() => enumValueNotDefined.CheckIsDefinedInEnum());
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(enumValueNotDefined)), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain($"{enumValueNotDefined}"), nameof(ex.Message));
        }


        [TestCase(TestEnum.MinusHundred)]
        [TestCase(TestEnum.Zero)]
        [TestCase(TestEnum.Hundred)]
        public void CheckIsDefinedInEnum_EnumValueDefined_ReturnParamValue(TestEnum enumValueDefined)
        {
            var actual = enumValueDefined.CheckIsDefinedInEnum();

            Assert.That(actual, Is.EqualTo(enumValueDefined));
        }
        #endregion

        #endregion


        #region CheckIsInWhitelist

        #region CheckIsInWhitelist with paramName
        [TestCase(null, "paramA", "", "a")]
        [TestCase("c", "paramB", "c", "a", "b")]
        [TestCase("aa", "paramC", "aa", "a", "b", "c")]
        [TestCase("very long string that should be truncated when displayed in error message. Valid   xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx", "paramD", "very long string that should be truncated when displayed in error message. Valid   xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx ...", "aa", "a", "b", "c")]
        public void CheckIsInWhitelistWithParamName_WhitelistDoesNotContainValue_ThrowsArgumentException(string value, string paramName, string valueInErrorMsg, params string[] whitelist)
        {
            var ex = Assert.Throws<ArgumentException>(() => value.CheckIsInWhitelist(whitelist, paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain($"'{valueInErrorMsg}'"), nameof(ex.Message));

        }


        [TestCase(null, "paramA", null)]
        [TestCase(null, "paramB", "a", null, "b")]
        [TestCase("b", "paramC", "a", "b", "c")]
        [TestCase("c", "paramD", "a", "b", "c")]
        public void CheckIsInWhitelistWithParamName_WhitelistContainValue_ReturnParamValue(string value, string paramName, params string[] whitelist)
        {
            var actual = value.CheckIsInWhitelist(whitelist, paramName);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion

        #region CheckIsInWhitelist without paramName
        [TestCase(null, "", "a")]
        [TestCase("c", "c", "a", "b")]
        [TestCase("aa", "aa", "a", "b", "c")]
        [TestCase("very long string that should be truncated when displayed in error message. Valid   xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx", "very long string that should be truncated when displayed in error message. Valid   xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx ...", "aa", "a", "b", "c")]
        public void CheckIsInWhitelist_WhitelistDoesNotContainValue_ThrowsArgumentException(string value, string valueInErrorMsg, params string[] whitelist)
        {
            var ex = Assert.Throws<ArgumentException>(() => value.CheckIsInWhitelist(whitelist));
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(value)), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain($"'{valueInErrorMsg}'"), nameof(ex.Message));

        }


        [TestCase(null, new string?[] { null })]
        [TestCase(null, "a", null, "b")]
        [TestCase("b", "a", "b", "c")]
        [TestCase("c", "a", "b", "c")]
        public void CheckIsInWhitelist_WhitelistContainValue_ReturnParamValue(string value, params string[] whitelist)
        {
            var actual = value.CheckIsInWhitelist(whitelist);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion

        #endregion
    }
}