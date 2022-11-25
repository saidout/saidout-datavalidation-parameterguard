using NUnit.Framework;

namespace SaidOut.DataValidation.ParameterGuard.Tests
{

    public class GuardHelper_Tests
    {

        #region 

        #region ThrowIfParamXIsLessThanParamY with paramName
        [TestCase(-2, -1, "paramA1", "paramB1")]
        [TestCase(0, 1, "paramA2", "paramB2")]
        [TestCase(-1, 1, "paramA3", "paramB3")]
        public void ThrowIfParamXIsLessThanParamYWithParamName_ValueXIsGreaterThanValueY_ThrowsArgumentException(int valueX, int valueY, string nameX, string nameY)
        {
            var ex = Assert.Throws<ArgumentException>(() => GuardHelper.ThrowIfParamXIsLessThanParamY(valueX,  valueY, nameX, nameY));
            Assert.That(ex?.ParamName, Is.EqualTo(nameX), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain("less than").And.Contain(nameX).And.Contain(nameY), nameof(ex.Message));
        }


        [TestCase(-1, -1, "paramA1", "paramB1")]
        [TestCase(1, 1, "paramA2", "paramB2")]
        [TestCase(-1, -2, "paramA3", "paramB3")]
        [TestCase(0, -1, "paramA4", "paramB4")]
        [TestCase(3, 2, "paramA5", "paramB5")]
        public void ThrowIfParamXIsLessThanParamYWithParamName_ValueXIsEqualOrLessThanValueY_DoesNotThrow(int valueX, int valueY, string nameX, string nameY)
        {
            Assert.DoesNotThrow(() => GuardHelper.ThrowIfParamXIsLessThanParamY(valueX, valueY, nameX, nameY));
        }
        #endregion

        #region ThrowIfParamXIsLessThanParamY without paramName
        [TestCase(-2, -1)]
        [TestCase(0, 1)]
        [TestCase(-1, 1)]
        public void ThrowIfParamXIsLessThanParamY_ValueXIsGreaterThanValueY_ThrowsArgumentException(int valueX, int valueY)
        {
            var valXParam = valueX;
            var valYParam = valueY;

            var ex = Assert.Throws<ArgumentException>(() => GuardHelper.ThrowIfParamXIsLessThanParamY(valXParam, valYParam));
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(valXParam)), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain("less than").And.Contain(nameof(valXParam)).And.Contain(nameof(valYParam)), nameof(ex.Message));
        }


        [TestCase(-1, -1)]
        [TestCase(1, 1)]
        [TestCase(-1, -2)]
        [TestCase(0, -1)]
        [TestCase(3, 2)]
        public void ThrowIfParamXIsLessThanParamY_ValueXIsEqualOrLessThanValueY_DoesNotThrow(int valueX, int valueY)
        {
            Assert.DoesNotThrow(() => GuardHelper.ThrowIfParamXIsLessThanParamY(valueX, valueY));
        }
        #endregion

        #endregion


        #region ThrowIfParamXIsEqualOrLessThanParamY

        #region ThrowIfParamXIsEqualOrLessThanParamY with paramName
        [TestCase(-1, -1, "paramA1", "paramB1")]
        [TestCase(1, 1, "paramA2", "paramB2")]
        [TestCase(-2, -1, "paramA3", "paramB3")]
        [TestCase(0, 1, "paramA4", "paramB4")]
        [TestCase(-1, 1, "paramA5", "paramB5")]
        public void ThrowIfParamXIsEqualOrLessThanParamYWithParamName_ValueXIsEqualOrGreaterThanValueY_ThrowsArgumentException(int valueX, int valueY, string nameX, string nameY)
        {
            var ex = Assert.Throws<ArgumentException>(() => GuardHelper.ThrowIfParamXIsEqualOrLessThanParamY(valueX, valueY, nameX, nameY));
            Assert.That(ex?.ParamName, Is.EqualTo(nameX), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain("equal or less than").And.Contain(nameX).And.Contain(nameY), nameof(ex.Message));
        }


        [TestCase(-1, -2, "paramA1", "paramB1")]
        [TestCase(0, -1, "paramA2", "paramB2")]
        [TestCase(3, 2, "paramA3", "paramB3")]
        public void ThrowIfParamXIsEqualOrLessThanParamYWithParamName_ValueXIsLessThanValueY_DoesNotThrow(int valueX, int valueY, string nameX, string nameY)
        {
            Assert.DoesNotThrow(() => GuardHelper.ThrowIfParamXIsEqualOrLessThanParamY(valueX, valueY, nameX, nameY));
        }
        #endregion

        #region ThrowIfParamXIsEqualOrLessThanParamY without paramName
        [TestCase(-1, -1)]
        [TestCase(1, 1)]
        [TestCase(-2, -1)]
        [TestCase(0, 1)]
        [TestCase(-1, 1)]
        public void ThrowIfParamXIsEqualOrLessThanParamY_ValueXIsEqualOrGreaterThanValueY_ThrowsArgumentException(int valueX, int valueY)
        {
            var valXParam = valueX;
            var valYParam = valueY;

            var ex = Assert.Throws<ArgumentException>(() => GuardHelper.ThrowIfParamXIsEqualOrLessThanParamY(valXParam, valYParam));
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(valXParam)), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain("equal or less than").And.Contain(nameof(valXParam)).And.Contain(nameof(valYParam)), nameof(ex.Message));
        }


        [TestCase(-1, -2)]
        [TestCase(0, -1)]
        [TestCase(3, 2)]
        public void ThrowIfParamXIsEqualOrLessThanParamY_ValueXIsLessThanValueY_DoesNotThrow(int valueX, int valueY)
        {
            Assert.DoesNotThrow(() => GuardHelper.ThrowIfParamXIsEqualOrLessThanParamY(valueX, valueY));
        }
        #endregion

        #endregion


        #region ThrowIfParamXIsGreaterThanParamY

        #region ThrowIfParamXIsGreaterThanParamY with paramName
        [TestCase(-1, -2, "paramA1", "paramB1")]
        [TestCase(1, 0, "paramA2", "paramB2")]
        [TestCase(1, -1, "paramA3", "paramB3")]
        public void ThrowIfParamXIsGreaterThanParamYWithParamName_ValueXIsGreaterThanValueY_ThrowsArgumentException(int valueX, int valueY, string nameX, string nameY)
        {
            var ex = Assert.Throws<ArgumentException>(() =>  GuardHelper.ThrowIfParamXIsGreaterThanParamY(valueX, valueY, nameX, nameY));
            Assert.That(ex?.ParamName, Is.EqualTo(nameX), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain("greater than").And.Contain(nameX).And.Contain(nameY), nameof(ex.Message));
        }


        [TestCase(-1, -1, "paramA1", "paramB1")]
        [TestCase(1, 1, "paramA2", "paramB2")]
        [TestCase(-2, -1, "paramA3", "paramB3")]
        [TestCase(-1, 0, "paramA4", "paramB4")]
        [TestCase(2, 3, "paramA5", "paramB5")]
        public void ThrowIfParamXIsGreaterThanParamYWithParamName_ValueXIsEqualOrLessThanValueX_DoesNotThrow(int valueX, int valueY, string nameX, string nameY)
        {
            Assert.DoesNotThrow(() => GuardHelper.ThrowIfParamXIsGreaterThanParamY(valueX, valueY, nameX, nameY));
        }
        #endregion

        #region ThrowIfParamXIsGreaterThanParamY without paramName
        [TestCase(-1, -2)]
        [TestCase(1, 0)]
        [TestCase(1, -1)]
        public void ThrowIfParamXIsGreaterThanParamY_ValueXIsGreaterThanValueY_ThrowsArgumentException(int valueX, int valueY)
        {
            var valXParam = valueX;
            var valYParam = valueY;

            var ex = Assert.Throws<ArgumentException>(() => GuardHelper.ThrowIfParamXIsGreaterThanParamY(valXParam, valYParam));
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(valXParam)), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain("greater than").And.Contain(nameof(valXParam)).And.Contain(nameof(valYParam)), nameof(ex.Message));
        }


        [TestCase(-1, -1)]
        [TestCase(1, 1)]
        [TestCase(-2, -1)]
        [TestCase(-1, 0)]
        [TestCase(2, 3)]
        public void ThrowIfParamXIsGreaterThanParamY_ValueXIsEqualOrLessThanValueX_DoesNotThrow(int valueX, int valueY)
        {
            Assert.DoesNotThrow(() => GuardHelper.ThrowIfParamXIsGreaterThanParamY(valueX, valueY));
        }
        #endregion

        #endregion


        #region ThrowIfParamXIsEqualOrGreaterThanParamY

        #region ThrowIfParamXIsEqualOrGreaterThanParamY with paramName
        [TestCase(-1, -1, "paramA1", "paramB1")]
        [TestCase(1, 1, "paramA2", "paramB2")]
        [TestCase(-1, -2, "paramA3", "paramB3")]
        [TestCase(1, 0, "paramA4", "paramB4")]
        [TestCase(1, -1, "paramA5", "paramB5")]
        public void ThrowIfParamXIsEqualOrGreaterThanParamYWithParamName_ValueXIsEqualOrGreaterThanValueY_ThrowsArgumentException(int valueX, int valueY, string nameX, string nameY)
        {
            var ex = Assert.Throws<ArgumentException>(() => GuardHelper.ThrowIfParamXIsEqualOrGreaterThanParamY(valueX, valueY, nameX, nameY));
            Assert.That(ex?.ParamName, Is.EqualTo(nameX), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain("equal or greater than").And.Contain(nameX).And.Contain(nameY), nameof(ex.Message));
        }


        [TestCase(-2, -1, "paramA1", "paramB1")]
        [TestCase(-1, 0, "paramA2", "paramB2")]
        [TestCase(2, 3, "paramA3", "paramB3")]
        public void ThrowIfParamXIsEqualOrGreaterThanParamYWithParamName_ValueXIsLessThanValueX_DoesNotThrow(int valueX, int valueY, string nameX, string nameY)
        {
            Assert.DoesNotThrow(() => GuardHelper.ThrowIfParamXIsEqualOrGreaterThanParamY(valueX, valueY, nameX, nameY));
        }
        #endregion

        #region ThrowIfParamXIsEqualOrGreaterThanParamY without paramName
        [TestCase(-1, -1)]
        [TestCase(1, 1)]
        [TestCase(-1, -2)]
        [TestCase(1, 0)]
        [TestCase(1, -1)]
        public void ThrowIfParamXIsEqualOrGreaterThanParamY_ValueXIsEqualOrGreaterThanValueY_ThrowsArgumentException(int valueX, int valueY)
        {
            var valXParam = valueX;
            var valYParam = valueY;

            var ex = Assert.Throws<ArgumentException>(() => GuardHelper.ThrowIfParamXIsEqualOrGreaterThanParamY(valXParam, valYParam));
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(valXParam)), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain("equal or greater than").And.Contain(nameof(valXParam)).And.Contain(nameof(valYParam)), nameof(ex.Message));
        }


        [TestCase(-2, -1)]
        [TestCase(-1, 0)]
        [TestCase(2, 3)]
        public void ThrowIfParamXIsEqualOrGreaterThanParamY_ValueXIsLessThanValueX_DoesNotThrow(int valueX, int valueY)
        {
            Assert.DoesNotThrow(() => GuardHelper.ThrowIfParamXIsEqualOrGreaterThanParamY(valueX, valueY));
        }
        #endregion

        #endregion
    }
} 