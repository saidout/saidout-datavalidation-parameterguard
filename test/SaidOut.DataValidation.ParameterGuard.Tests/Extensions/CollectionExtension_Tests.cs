using NUnit.Framework;
using SaidOut.DataValidation.ParameterGuard.Extensions;

namespace SaidOut.DataValidation.ParameterGuard.Tests.Extensions
{

    public class CollectionExtension_Tests
    {

        #region IEnumerable> CheckIsNotNullOrEmpty

        #region IEnumerable> CheckIsNotNullOrEmpty with paramName
        [TestCase("paramOne")]
        [TestCase("paramTwo")]
        public void CheckIsNotNullOrEmptyWithParamName_IEnumerableIsNull_ThrowsArgumentNullException(string paramName)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ((IEnumerable<string>?)null).CheckIsNotNullOrEmpty(paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
        }


        [TestCase("paramOne")]
        [TestCase("paramTwo")]
        public void CheckIsNotNullOrEmptyWithParamName_IEnumerableIsEmptyW_ThrowsArgumentException(string paramName)
        {
            IEnumerable<string> collection = new List<string>();

            var ex = Assert.Throws<ArgumentException>(() => collection.CheckIsNotNullOrEmpty(paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain("empty"), nameof(ex.Message));
        }


        [TestCase("paramOne")]
        [TestCase("paramTwo")]
        public void CheckIsNotNullOrEmptyWithParamName_IEnumerableHasItem_ReturnParamValue(string paramName)
        {
            IEnumerable<string> enumerable = new List<string> { "test" };

            var actual = enumerable.CheckIsNotNullOrEmpty(paramName);

            Assert.That(actual, Is.EqualTo(enumerable));
        }
        #endregion

        #region IEnumerable> CheckIsNotNullOrEmpty without paramName
        [Test]
        public void CheckIsNotNullOrEmpty_IEnumerableIsNull_ThrowsArgumentNullException()
        {
            var testParam = (IEnumerable<string>?) null;

            var ex = Assert.Throws<ArgumentNullException>(() => testParam.CheckIsNotNullOrEmpty());
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(testParam)), nameof(ex.ParamName));
        }


        [Test]
        public void CheckIsNotNullOrEmpty_IEnumerableIsEmpty_ThrowsArgumentException()
        {
            IEnumerable<string> collection = new List<string>();

            var ex = Assert.Throws<ArgumentException>(() => collection.CheckIsNotNullOrEmpty());
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(collection)), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain("empty"), nameof(ex.Message));
        }


        [Test]
        public void CheckIsNotNullOrEmpty_IEnumerableHasItem_ReturnParamValue()
        {
            IEnumerable<string> enumerable = new List<string> { "test" };

            var actual = enumerable.CheckIsNotNullOrEmpty();

            Assert.That(actual, Is.EqualTo(enumerable));
        }
        #endregion

        #endregion


        #region ICollection> CheckIsNotNullOrEmpty

        #region ICollection> CheckIsNotNullOrEmpty with paramName
        [TestCase("paramOne")]
        [TestCase("paramTwo")]
        public void CheckIsNotNullOrEmptyWithParamName_ICollectionIsNull_ThrowsArgumentNullException(string paramName)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ((ICollection<string>?)null).CheckIsNotNullOrEmpty(paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
        }


        [TestCase("paramOne")]
        [TestCase("paramTwo")]
        public void CheckIsNotNullOrEmptyWithParamName_ICollectionIsEmpty_ThrowsArgumentException(string paramName)
        {
            ICollection<string> collection = new List<string>();

            var ex = Assert.Throws<ArgumentException>(() => collection.CheckIsNotNullOrEmpty(paramName));
            Assert.That(ex?.ParamName, Is.EqualTo(paramName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain("empty"), nameof(ex.Message));
        }


        [TestCase("paramOne")]
        [TestCase("paramTwo")]
        public void CheckIsNotNullOrEmptyWithParamName_ICollectionHasItem_ReturnParamValue(string paramName)
        {
            ICollection<string> collection = new List<string> { "test" };

            var actual = collection.CheckIsNotNullOrEmpty(paramName);

            Assert.That(actual, Is.EqualTo(collection));
        }
        #endregion

        #region ICollection> CheckIsNotNullOrEmpty without paramName
        [Test]
        public void CheckIsNotNullOrEmpty_ICollectionIsNull_ThrowsArgumentNullException()
        {
            var testParam = (ICollection<string>?)null;

            var ex = Assert.Throws<ArgumentNullException>(() => testParam.CheckIsNotNullOrEmpty());
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(testParam)), nameof(ex.ParamName));
        }


        [Test]
        public void CheckIsNotNullOrEmpty_ICollectionIsEmpty_ThrowsArgumentException()
        {
            ICollection<string> collection = new List<string>();

            var ex = Assert.Throws<ArgumentException>(() => collection.CheckIsNotNullOrEmpty());
            Assert.That(ex?.ParamName, Is.EqualTo(nameof(collection)), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain("empty"), nameof(ex.Message));
        }


        [Test]
        public void CheckIsNotNullOrEmpty_ICollectionHasItem_ReturnParamValue()
        {
            ICollection<string> collection = new List<string> { "test" };

            var actual = collection.CheckIsNotNullOrEmpty();

            Assert.That(actual, Is.EqualTo(collection));
        }
        #endregion

        #endregion
    }
}