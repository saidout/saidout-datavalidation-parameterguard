using NUnit.Framework;
using System;

namespace SaidOut.DataValidation.ParameterGuard.Tests
{

    public class GuardHelper_Tests
    {

        #region ThrowIfParamXIsLessThanParamY
        [TestCase(-2, -1, "paramA1", "paramB1")]
        [TestCase(0, 1, "paramA2", "paramB2")]
        [TestCase(-1, 1, "paramA3", "paramB3")]
        public void ThrowIfParamXIsLessThanParamY_ValueXIsGreaterThanValueY_ThrowsArgumentException(int valueX, int valueY, string nameX, string nameY)
        {
            var ex = Assert.Throws<ArgumentException>(() => GuardHelper.ThrowIfParamXIsLessThanParamY(valueX, nameX, valueY, nameY));
            Assert.That(ex.ParamName, Is.EqualTo(nameX), nameof(ex.ParamName));
            Assert.That(ex.Message, Does.Contain("less than").And.Contain(nameX).And.Contain(nameY), nameof(ex.Message));
        }


        [TestCase(-1, -1)]
        [TestCase(1, 1)]
        [TestCase(-1, -2)]
        [TestCase(0, -1)]
        [TestCase(3, 2)]
        public void ThrowIfParamXIsLessThanParamY_ValueXIsEqualOrLessThanValueY_DoesNotThrow(int valueX, int valueY)
        {
            Assert.DoesNotThrow(() => GuardHelper.ThrowIfParamXIsLessThanParamY(valueX, "paramNameA", valueY, "paramNameB"));
        }
        #endregion


        #region ThrowIfParamXIsEqualOrLessThanParamY
        [TestCase(-1, -1, "paramA1", "paramB1")]
        [TestCase(1, 1, "paramA2", "paramB2")]
        [TestCase(-2, -1, "paramA3", "paramB3")]
        [TestCase(0, 1, "paramA4", "paramB4")]
        [TestCase(-1, 1, "paramA5", "paramB5")]
        public void ThrowIfParamXIsEqualOrLessThanParamY_ValueXIsEqualOrGreaterThanValueY_ThrowsArgumentException(int valueX, int valueY, string nameX, string nameY)
        {
            var ex = Assert.Throws<ArgumentException>(() => GuardHelper.ThrowIfParamXIsEqualOrLessThanParamY(valueX, nameX, valueY, nameY));
            Assert.That(ex.ParamName, Is.EqualTo(nameX), nameof(ex.ParamName));
            Assert.That(ex.Message, Does.Contain("equal or less than").And.Contain(nameX).And.Contain(nameY), nameof(ex.Message));
        }


        [TestCase(-1, -2)]
        [TestCase(0, -1)]
        [TestCase(3, 2)]
        public void ThrowIfParamXIsEqualOrLessThanParamY_ValueXIsLessThanValueY_DoesNotThrow(int valueA, int valueB)
        {
            Assert.DoesNotThrow(() => GuardHelper.ThrowIfParamXIsEqualOrLessThanParamY(valueA, "paramNameA", valueB, "paramNameB"));
        }
        #endregion


        #region ThrowIfParamXIsGreaterThanParamY
        [TestCase(-1, -2, "paramA1", "paramB1")]
        [TestCase(1, 0, "paramA2", "paramB2")]
        [TestCase(1, -1, "paramA3", "paramB3")]
        public void ThrowIfParamXIsGreaterThanParamY_ValueXIsGreaterThanValueY_ThrowsArgumentException(int valueX, int valueY, string nameX, string nameY)
        {
            var ex = Assert.Throws<ArgumentException>(() =>  GuardHelper.ThrowIfParamXIsGreaterThanParamY(valueX, nameX, valueY, nameY));
            Assert.That(ex.ParamName, Is.EqualTo(nameX), nameof(ex.ParamName));
            Assert.That(ex.Message, Does.Contain("greater than").And.Contain(nameX).And.Contain(nameY), nameof(ex.Message));
        }


        [TestCase(-1, -1)]
        [TestCase(1, 1)]
        [TestCase(-2, -1)]
        [TestCase(-1, 0)]
        [TestCase(2, 3)]
        public void ThrowIfParamXIsGreaterThanParamY_ValueXIsEqualOrLessThanValueX_DoesNotThrow(int valueA, int valueB)
        {
            Assert.DoesNotThrow(() => GuardHelper.ThrowIfParamXIsGreaterThanParamY(valueA, "paramNameA", valueB, "paramNameB"));
        }
        #endregion


        #region ThrowIfParamXIsEqualOrGreaterThanParamY
        [TestCase(-1, -1, "paramA1", "paramB1")]
        [TestCase(1, 1, "paramA2", "paramB2")]
        [TestCase(-1, -2, "paramA3", "paramB3")]
        [TestCase(1, 0, "paramA4", "paramB4")]
        [TestCase(1, -1, "paramA5", "paramB5")]
        public void ThrowIfParamXIsEqualOrGreaterThanParamY_ValueXIsEqualOrGreaterThanValueY_ThrowsArgumentException(int valueX, int valueY, string nameX, string nameY)
        {
            var ex = Assert.Throws<ArgumentException>(() => GuardHelper.ThrowIfParamXIsEqualOrGreaterThanParamY(valueX, nameX, valueY, nameY));
            Assert.That(ex.ParamName, Is.EqualTo(nameX), nameof(ex.ParamName));
            Assert.That(ex.Message, Does.Contain("equal or greater than").And.Contain(nameX).And.Contain(nameY), nameof(ex.Message));
        }


        [TestCase(-2, -1)]
        [TestCase(-1, 0)]
        [TestCase(2, 3)]
        public void ThrowIfParamXIsEqualOrGreaterThanParamY_ValueXIsLessThanValueX_DoesNotThrow(int valueA, int valueB)
        {
            Assert.DoesNotThrow(() => GuardHelper.ThrowIfParamXIsEqualOrGreaterThanParamY(valueA, "paramNameA", valueB, "paramNameB"));
        }
        #endregion
    }
}