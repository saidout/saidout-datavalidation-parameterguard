using NUnit.Framework;
using SaidOut.DataValidation.ParameterGuard.Extensions;
using System;

namespace SaidOut.DataValidation.ParameterGuard.Tests.Extensions
{

    public class ComparableExtension_Tests
    {
        private const string DefaultParamName = "paramName";


        #region CheckIsInsideRange
        [TestCase(-2, -1, 1, "paramA")]
        [TestCase(2, -1, 1, "paramB")]
        public void CheckIsInsideRange_ValueIsNotInsideRange_ThrowsArgumentOutOfRangeException(int value, int lowerBound, int upperBound, string paramName)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.CheckIsInsideRange(lowerBound, upperBound, paramName));
            Assert.That(ex.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex.Message, Does.Contain(lowerBound.ToString()).And.Contain(upperBound.ToString()).And.Contain(value.ToString()));
        }


        [TestCase(-1, -1, 1)]
        [TestCase(0, -1, 1)]
        [TestCase(1, -1, 1)]
        public void CheckIsInsideRange_ValueIsInsideRange_ReturnParamValue(int value, int minValue, int maxValue)
        {
            var actual = value.CheckIsInsideRange(minValue, maxValue, DefaultParamName);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion


        #region CheckIsGreaterThan
        [TestCase(-2, -1, "paramA")]
        [TestCase(-1, -1, "paramA")]
        [TestCase(0, 1, "paramA")]
        [TestCase(4, 5, "paramB")]
        public void CheckIsGreaterThan_ValueIsEqualOrLessThanLowerBound_ThrowsArgumentOutOfRangeException(int value, int lowerBound, string paramName)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.CheckIsGreaterThan(lowerBound, paramName));
            Assert.That(ex.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex.Message, Does.Contain(lowerBound.ToString()).And.Contain(value.ToString()));
        }


        [TestCase(-1, -2)]
        [TestCase(-1, -3)]
        [TestCase(0, -1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        public void CheckIsGreaterThan_ValueIsGreaterThanLowerBound_ReturnParamValue(int value, int lowerBound)
        {
            var actual = value.CheckIsGreaterThan(lowerBound, DefaultParamName);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion



        #region CheckIsEqualOrGreaterThan
        [TestCase(-2, -1, "paramA")]
        [TestCase(0, 1, "paramA")]
        [TestCase(4, 5, "paramB")]
        public void CheckIsEqualOrGreaterThan_ValueIsLessThanLowerBound_ThrowsArgumentOutOfRangeException(int value, int lowerBound, string paramName)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.CheckIsEqualOrGreaterThan(lowerBound, paramName));
            Assert.That(ex.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex.Message, Does.Contain(lowerBound.ToString()).And.Contain(value.ToString()));
        }


        [TestCase(1, 1)]
        [TestCase(-1, -2)]
        [TestCase(-1, -3)]
        [TestCase(0, -1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(-1, -1)]
        public void CheckIsEqualOrGreaterThan_ValueIsEqualOrGreaterThanLowerBound_ReturnParamValue(int value, int lowerBound)
        {
            var actual = value.CheckIsEqualOrGreaterThan(lowerBound, DefaultParamName);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion


        #region CheckIsLessThan
        [TestCase(-1, -1, "paramA")]
        [TestCase(-1, -2, "paramA")]
        [TestCase(1, 0, "paramA")]
        [TestCase(2, 1, "paramB")]
        public void CheckIsLessThan_ValueIsEqualOrGreaterThanUpperBound_ThrowsArgumentOutOfRangeException(int value, int upperBound, string paramName)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.CheckIsLessThan(upperBound, paramName));
            Assert.That(ex.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex.Message, Does.Contain(upperBound.ToString()).And.Contain(value.ToString()));
        }


        [TestCase(-2, -1)]
        [TestCase(-3, -1)]
        [TestCase(-1, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void CheckIsLessThan_ValueIsLessThanUpperBound_ReturnParamValue(int value, int upperBound)
        {
            var actual = value.CheckIsLessThan(upperBound, DefaultParamName);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion


        #region CheckIsEqualOrLessThan
        [TestCase(-1, -2, "paramA")]
        [TestCase(1, 0, "paramA")]
        [TestCase(2, 1, "paramB")]
        public void CheckIsEqualOrLessThan_ValueIsGreaterThanUpperBound_ThrowsArgumentOutOfRangeException(int value, int upperBound, string paramName)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.CheckIsEqualOrLessThan(upperBound, paramName));
            Assert.That(ex.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex.Message, Does.Contain(upperBound.ToString()).And.Contain(value.ToString()));
        }


        [TestCase(-1, -1)]
        [TestCase(-2, -1)]
        [TestCase(-3, -1)]
        [TestCase(-1, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void CheckIsEqualOrLessThan_ValueIsEqualOrLessThanUpperBound_ReturnParamValue(int value, int upperBound)
        {
            var actual = value.CheckIsEqualOrLessThan(upperBound, DefaultParamName);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion
    }
}