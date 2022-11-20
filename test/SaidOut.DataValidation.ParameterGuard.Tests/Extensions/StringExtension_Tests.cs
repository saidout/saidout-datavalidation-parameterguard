using NUnit.Framework;
using SaidOut.DataValidation.ParameterGuard.Extensions;
using System;

namespace SaidOut.DataValidation.ParameterGuard.Tests.Extensions
{
    public class StringExtension_Tests
    {
        private const string DefaultParamName = "paramName";


        #region CheckIsNotNullOrBlank
        [TestCase("paramA")]
        [TestCase("paramB")]
        public void CheckIsNotNullOrBlank_ValueIsNull_ThrowsArgumentNullException(string paramName)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ((string?)null).CheckIsNotNullOrBlank(paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
        }


        [TestCase("", "paramA")]
        [TestCase(" ", "paramB")]
        [TestCase("\t", "paramC")]
        [TestCase("\n", "paramD")]
        public void CheckIsNotNullOrBlank_ValueIsEmptyOrBlank_ThrowsArgumentException(string value, string paramName)
        {
            var ex = Assert.Throws<ArgumentException>(() => value.CheckIsNotNullOrBlank(paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain("can't be blank"), nameof(ex.Message));
        }


        [Test]
        public void CheckIsNotNullOrBlank_ValueIsNotNullOrBlank_ReturnParamValue()
        {
            var str = "test";

            var actual = str.CheckIsNotNullOrBlank(DefaultParamName);

            Assert.That(actual, Is.EqualTo(str));
        }
        #endregion


        #region CheckMatchRegexPattern
        [TestCase("paramA")]
        [TestCase("paramB")]
        public void CheckMatchRegexPattern_ValueIsNull_ThrowsArgumentNullException(string paramName)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ((string?)null).CheckMatchRegexPattern("^[a-z]*$", paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
        }


        [TestCase("ab", "^abc$", "paramA", "ab")]
        [TestCase("abb", "^abc$", "paramB", "abb")]
        [TestCase("very long string that should be truncated when displayed in error message. RegEx   xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx", "^abc$", "paramB", "very long string that should be truncated when displayed in error message. RegEx   xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx ...")]
        public void CheckMatchRegexPattern_ValueDoesNotMatchRegexPattern_ThrowsArgumentException(string value, string regexPattern, string paramName, string valueInErrorMsg)
        {
            var ex = Assert.Throws<ArgumentException>(() => value.CheckMatchRegexPattern(regexPattern, paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain(regexPattern).And.Contain($"'{valueInErrorMsg}'"), nameof(ex.Message));
        }


        [TestCase("abc", "^abc$")]
        [TestCase("az", "^[a-z]{2,2}$")]
        public void CheckMatchRegexPattern_ValueMatchRegexPattern_ReturnParamValue(string value, string regexPattern)
        {
            var actual = value.CheckMatchRegexPattern(regexPattern, DefaultParamName);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion


        #region CheckIsHexString
        [TestCase("paramA")]
        [TestCase("paramB")]
        public void CheckIsHexString_ValueIsNull_ThrowsArgumentNullException(string paramName)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ((string?)null).CheckIsHexString(paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
        }


        [TestCase("x", "paramB", "x")]
        [TestCase("xx", "paramC", "xx")]
        [TestCase("124t", "paramD", "124t")]
        [TestCase("0x122", "paramF", "0x122")]
        [TestCase("0x12Ga", "paramG", "0x12Ga")]
        [TestCase("0x0x12aa", "paramF", "0x0x12aa")]
        [TestCase("very long string that should be truncated when displayed in error message. Hex xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx", "paramG", "very long string that should be truncated when displayed in error message. Hex xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx ...")]
        public void CheckIsHexString_ValueIsNotHexString_ThrowsArgumentException(string value, string paramName, string valueInErrorMsg)
        {
            var ex = Assert.Throws<ArgumentException>(() => value.CheckIsHexString(paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain($"'{valueInErrorMsg}'"), nameof(ex.Message));
        }


        [TestCase("", 1, "paramA", "<EMPTY>")]
        [TestCase("0x", 1, "paramB", "0x")]
        [TestCase("01", 2, "paramC", "01")]
        [TestCase("0x01", 2, "paramD", "0x01")]
        [TestCase("01020304050607", 8, "paramE", "01020304050607")]
        [TestCase("0x01020304050607", 8, "paramF", "0x01020304050607")]
        [TestCase("00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF", 300, "paramH", "00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AAB...")]
        public void CheckIsHexString_ByteIsLessThanMinByteSize_ThrowsArgumentException(string value, int minByteSize, string paramName, string valueInErrorMsg)
        {
            var ex = Assert.Throws<ArgumentException>(() => value.CheckIsHexString(paramName, minByteSize));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain(minByteSize.ToString()).And.Contain($"{valueInErrorMsg}").And.Not.Contain($"[{minByteSize}, {int.MaxValue}]"), nameof(ex.Message));
        }


        [TestCase("0102", 1, "paramA", "0102")]
        [TestCase("0x0102", 1, "paramB", "0x0102")]
        [TestCase("01020304050607", 6, "paramC", "01020304050607")]
        [TestCase("0x01020304050607", 6, "paramD", "0x01020304050607")]
        [TestCase("11112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF", 10, "paramE", "11112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AAB...")]
        public void CheckIsHexString_ByteIsGreaterThanMaxByteSize_ThrowsArgumentException(string value, int maxByteSize, string paramName, string valueInErrorMsg)
        {
            var ex = Assert.Throws<ArgumentException>(() => value.CheckIsHexString(paramName, 0, maxByteSize));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain(maxByteSize.ToString()).And.Contain($"{valueInErrorMsg}").And.Not.Contain($"[{0}, {int.MaxValue}]"), nameof(ex.Message));
        }


        [TestCase("", 1, 2, "paramA", "<EMPTY>")]
        [TestCase("0x", 1, 2, "paramB", "0x")]
        [TestCase("010203", 1, 2, "paramA", "010203")]
        [TestCase("0x010203", 1, 2, "paramB", "0x010203")]
        [TestCase("01020304", 5, 7, "paramC", "01020304")]
        [TestCase("0102030405060708", 5, 7, "paramD", "0102030405060708")]
        [TestCase("22112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF", 10, 20, "paramE", "22112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AAB...")]
        public void CheckIsHexString_ByteIsOutsideAllowedRange_ThrowsArgumentException(string value, int minByteSize, int maxByteSize, string paramName, string valueInErrorMsg)
        {
            var ex = Assert.Throws<ArgumentException>(() => value.CheckIsHexString(paramName, minByteSize, maxByteSize));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain($"[{minByteSize}, {maxByteSize}]").And.Contain($"{valueInErrorMsg}"), nameof(ex.Message));
        }


        [TestCase("", 0, int.MaxValue)]
        [TestCase("0x", 0, int.MaxValue)]
        [TestCase("010203", 0, int.MaxValue)]
        [TestCase("0x010203", 0, int.MaxValue)]
        [TestCase("010203", 3, int.MaxValue)]
        [TestCase("0x010203", 3, int.MaxValue)]
        [TestCase("010203", 0, 3)]
        [TestCase("0x010203", 0, 3)]
        [TestCase("0102030405", 5, 7)]
        [TestCase("010203040506", 5, 7)]
        [TestCase("01020304050607", 5, 7)]
        public void CheckIsHexString_ValueIsHexStringWithBytesInsideAllowedRange_ReturnParamValue(string value, int minByteSize, int maxByteSize)
        {
            var actual = value.CheckIsHexString(DefaultParamName, minByteSize, maxByteSize);

            Assert.That(actual, Is.EqualTo(value));
        }


        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void CheckIsHexString_MinByteSizeIsLessThanZero_Throws(int minByteSize)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => "010203".CheckIsHexString(DefaultParamName, minByteSize));
            Assert.That(ex?.ParamName, Is.EqualTo("minByteSize"), nameof(ex.ParamName));
        }
        #endregion
    }
}