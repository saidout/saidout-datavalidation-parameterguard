using NUnit.Framework;
using SaidOut.DataValidation.ParameterGuard.Extensions;

namespace SaidOut.DataValidation.ParameterGuard.Tests.Extensions
{

    public class ComparableExtension_Tests
    {

        #region CheckIsInsideRange

        #region CheckIsInsideRange with paramName
        [TestCase(-2, -1, 1, "paramA")]
        [TestCase(2, -1, 1, "paramB")]
        public void CheckIsInsideRangeWithParamName_ValueIsNotInsideRange_ThrowsArgumentOutOfRangeException(int value, int lowerBound, int upperBound, string paramName)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.CheckIsInsideRange(lowerBound, upperBound, paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain(lowerBound.ToString()).And.Contain(upperBound.ToString()).And.Contain(value.ToString()));
        }


        [TestCase(-1, -1, 1, "paramA")]
        [TestCase(0, -1, 1, "paramB")]
        [TestCase(1, -1, 1, "paramC")]
        public void CheckIsInsideRangeWithParamName_ValueIsInsideRange_ReturnParamValue(int value, int minValue, int maxValue, string paramName)
        {
            var actual = value.CheckIsInsideRange(minValue, maxValue, paramName);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion

        #region CheckIsInsideRange without paramName
        [TestCase(-2, -1, 1)]
        [TestCase(2, -1, 1)]
        public void CheckIsInsideRange_ValueIsNotInsideRange_ThrowsArgumentOutOfRangeException(int value, int lowerBound, int upperBound)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.CheckIsInsideRange(lowerBound, upperBound));
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(value)), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain(lowerBound.ToString()).And.Contain(upperBound.ToString()).And.Contain(value.ToString()));
        }


        [TestCase(-1, -1, 1)]
        [TestCase(0, -1, 1)]
        [TestCase(1, -1, 1)]
        public void CheckIsInsideRange_ValueIsInsideRange_ReturnParamValue(int value, int minValue, int maxValue)
        {
            var actual = value.CheckIsInsideRange(minValue, maxValue);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion

        #endregion


        #region CheckIsGreaterThan

        #region CheckIsInsideRange with paramName
        [TestCase(-2, -1, "paramA")]
        [TestCase(-1, -1, "paramB")]
        [TestCase(0, 1, "paramC")]
        [TestCase(4, 5, "paramD")]
        public void CheckIsGreaterThanWithParamName_ValueIsEqualOrLessThanLowerBound_ThrowsArgumentOutOfRangeException(int value, int lowerBound, string paramName)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.CheckIsGreaterThan(lowerBound, paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain(lowerBound.ToString()).And.Contain(value.ToString()));
        }


        [TestCase(-1, -2, "paramA")]
        [TestCase(-1, -3, "paramB")]
        [TestCase(0, -1, "paramC")]
        [TestCase(2, 1, "paramD")]
        [TestCase(3, 2, "paramE")]
        public void CheckIsGreaterThanWithParamName_ValueIsGreaterThanLowerBound_ReturnParamValue(int value, int lowerBound, string paramName)
        {
            var actual = value.CheckIsGreaterThan(lowerBound, paramName);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion

        #region CheckIsInsideRange without paramName
        [TestCase(-2, -1)]
        [TestCase(-1, -1)]
        [TestCase(0, 1)]
        [TestCase(4, 5)]
        public void CheckIsGreaterThan_ValueIsEqualOrLessThanLowerBound_ThrowsArgumentOutOfRangeException(int value, int lowerBound)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.CheckIsGreaterThan(lowerBound));
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(value)), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain(lowerBound.ToString()).And.Contain(value.ToString()));
        }


        [TestCase(-1, -2)]
        [TestCase(-1, -3)]
        [TestCase(0, -1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        public void CheckIsGreaterThan_ValueIsGreaterThanLowerBound_ReturnParamValue(int value, int lowerBound)
        {
            var actual = value.CheckIsGreaterThan(lowerBound);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion

        #endregion


        #region CheckIsEqualOrGreaterThan

        #region CheckIsEqualOrGreaterThan with paramName
        [TestCase(-2, -1, "paramA")]
        [TestCase(0, 1, "paramB")]
        [TestCase(4, 5, "paramC")]
        public void CheckIsEqualOrGreaterThanWithParamName_ValueIsLessThanLowerBound_ThrowsArgumentOutOfRangeException(int value, int lowerBound, string paramName)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.CheckIsEqualOrGreaterThan(lowerBound, paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain(lowerBound.ToString()).And.Contain(value.ToString()));
        }


        [TestCase(1, 1, "paramA")]
        [TestCase(-1, -2, "paramB")]
        [TestCase(-1, -3, "paramC")]
        [TestCase(0, -1, "paramD")]
        [TestCase(2, 1, "paramE")]
        [TestCase(3, 2, "paramF")]
        [TestCase(-1, -1, "paramG")]
        public void CheckIsEqualOrGreaterThanWithParamName_ValueIsEqualOrGreaterThanLowerBound_ReturnParamValue(int value, int lowerBound, string paramName)
        {
            var actual = value.CheckIsEqualOrGreaterThan(lowerBound, paramName);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion

        #region CheckIsEqualOrGreaterThan without paramName
        [TestCase(-2, -1)]
        [TestCase(0, 1)]
        [TestCase(4, 5)]
        public void CheckIsEqualOrGreaterThan_ValueIsLessThanLowerBound_ThrowsArgumentOutOfRangeException(int value, int lowerBound)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.CheckIsEqualOrGreaterThan(lowerBound));
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(value)), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain(lowerBound.ToString()).And.Contain(value.ToString()));
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
            var actual = value.CheckIsEqualOrGreaterThan(lowerBound);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion

        #endregion


        #region CheckIsLessThan

        #region CheckIsLessThan with paramName
        [TestCase(-1, -1, "paramA")]
        [TestCase(-1, -2, "paramB")]
        [TestCase(1, 0, "paramC")]
        [TestCase(2, 1, "paramD")]
        public void CheckIsLessThanWithParamName_ValueIsEqualOrGreaterThanUpperBound_ThrowsArgumentOutOfRangeException(int value, int upperBound, string paramName)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.CheckIsLessThan(upperBound, paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain(upperBound.ToString()).And.Contain(value.ToString()));
        }


        [TestCase(-2, -1, "paramA")]
        [TestCase(-3, -1, "paramB")]
        [TestCase(-1, 0, "paramC")]
        [TestCase(0, 1, "paramD")]
        [TestCase(1, 2, "paramE")]
        [TestCase(2, 3, "paramF")]
        public void CheckIsLessThanWithParamName_ValueIsLessThanUpperBound_ReturnParamValue(int value, int upperBound, string paramName)
        {
            var actual = value.CheckIsLessThan(upperBound, paramName);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion

        #region CheckIsLessThan without paramName
        [TestCase(-1, -1)]
        [TestCase(-1, -2)]
        [TestCase(1, 0)]
        [TestCase(2, 1)]
        public void CheckIsLessThan_ValueIsEqualOrGreaterThanUpperBound_ThrowsArgumentOutOfRangeException(int value, int upperBound)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.CheckIsLessThan(upperBound));
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(value)), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain(upperBound.ToString()).And.Contain(value.ToString()));
        }


        [TestCase(-2, -1)]
        [TestCase(-3, -1)]
        [TestCase(-1, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void CheckIsLessThan_ValueIsLessThanUpperBound_ReturnParamValue(int value, int upperBound)
        {
            var actual = value.CheckIsLessThan(upperBound);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion

        #endregion


        #region CheckIsEqualOrLessThan

        #region CheckIsEqualOrLessThan with paramName
        [TestCase(-1, -2, "paramA")]
        [TestCase(1, 0, "paramB")]
        [TestCase(2, 1, "paramC")]
        public void CheckIsEqualOrLessThanWithParamName_ValueIsGreaterThanUpperBound_ThrowsArgumentOutOfRangeException(int value, int upperBound, string paramName)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.CheckIsEqualOrLessThan(upperBound, paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain(upperBound.ToString()).And.Contain(value.ToString()));
        }


        [TestCase(-1, -1, "paramA")]
        [TestCase(-2, -1, "paramB")]
        [TestCase(-3, -1, "paramC")]
        [TestCase(-1, 0, "paramD")]
        [TestCase(0, 1, "paramE")]
        [TestCase(1, 2, "paramF")]
        [TestCase(2, 3, "paramG")]
        public void CheckIsEqualOrLessThanWithParamName_ValueIsEqualOrLessThanUpperBound_ReturnParamValue(int value, int upperBound, string paramName)
        {
            var actual = value.CheckIsEqualOrLessThan(upperBound, paramName);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion

        #region CheckIsEqualOrLessThan without paramName
        [TestCase(-1, -2)]
        [TestCase(1, 0)]
        [TestCase(2, 1)]
        public void CheckIsEqualOrLessThan_ValueIsGreaterThanUpperBound_ThrowsArgumentOutOfRangeException(int value, int upperBound)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => value.CheckIsEqualOrLessThan(upperBound));
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(value)), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain(upperBound.ToString()).And.Contain(value.ToString()));
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
            var actual = value.CheckIsEqualOrLessThan(upperBound);

            Assert.That(actual, Is.EqualTo(value));
        }
        #endregion

        #endregion
    }
}