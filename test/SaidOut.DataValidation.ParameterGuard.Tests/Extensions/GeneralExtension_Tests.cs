using NUnit.Framework;
using SaidOut.DataValidation.ParameterGuard.Extensions;
using System;

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
        [TestCase("paramA")]
        [TestCase("paramB")]
        public void CheckIsNotNull_ValueIsNull_ThrowsArgumentNullException(string paramName)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ((object)null).CheckIsNotNull(paramName));
            Assert.That(ex.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
        }


        [Test]
        public void CheckIsNotNull_ValueIsNotNull_ReturnParamValue()
        {
            var obj = new object();

            var actual = obj.CheckIsNotNull(DefaultParamName);

            Assert.That(actual, Is.EqualTo(obj));
        }
        #endregion


        #region CheckIsDefinedInEnum
        [TestCase(5, "paramA")]
        [TestCase(25, "paramB")]
        public void CheckIsDefinedInEnum_EnumValueNotDefined_ThrowsArgumentException(int valueNotDefined, string paramName)
        {
            TestEnum enumValueNotDefined = (TestEnum)valueNotDefined;

            var ex = Assert.Throws<ArgumentException>(() => enumValueNotDefined.CheckIsDefinedInEnum(paramName));
            Assert.That(ex.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex.Message, Does.Contain($"{enumValueNotDefined}"), nameof(ex.Message));
        }


        [TestCase(TestEnum.MinusHundred)]
        [TestCase(TestEnum.Zero)]
        [TestCase(TestEnum.Hundred)]
        public void CheckIsDefinedInEnum_EnumValueDefined_ReturnParamValue(TestEnum enumValueDefined)
        {
            var actual = enumValueDefined.CheckIsDefinedInEnum(DefaultParamName);

            Assert.That(actual, Is.EqualTo(enumValueDefined));
        }
        #endregion


        #region CheckIsInWhitelist
        [TestCase(null, "testA", "", "a")]
        [TestCase("c", "testB", "c", "a", "b")]
        [TestCase("aa", "testC", "aa", "a", "b", "c")]
        [TestCase("very long string that should be truncated when displayed in error message. Valid   xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx", "testD", "very long string that should be truncated when displayed in error message. Valid   xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx ...", "aa", "a", "b", "c")]
        public void CheckIsInWhitelist_WhitelistDoesNotContainValue_ThrowsArgumentException(string value, string paramName, string valueInErrorMsg, params string[] whitelist)
        {
            var ex = Assert.Throws<ArgumentException>(() => value.CheckIsInWhitelist(whitelist, paramName));
            Assert.That(ex.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex.Message, Does.Contain($"'{valueInErrorMsg}'"), nameof(ex.Message));

        }


        [TestCase(null, new string[] { null })]
        [TestCase(null, "a", null, "b")]
        [TestCase("b", "a", "b", "c")]
        [TestCase("c", "a", "b", "c")]
        public void CheckIsInWhitelist_WhitelistContainValue_ReturnParamValue(string value, params string[] whitelist)
        {
            var actual = value.CheckIsInWhitelist(whitelist, DefaultParamName);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion
    }
}