using NUnit.Framework;
using SaidOut.DataValidation.ParameterGuard.Extensions;
using System;
using System.Collections.Generic;

namespace SaidOut.DataValidation.ParameterGuard.Tests.Extensions
{

    public class CollectionExtension_Tests
    {
        private const string TestParamName = "TestParamName";


        #region IEnumerable> CheckIsNotNullOrEmpty
        [Test]
        public void CheckIsNotNullOrEmpty_IEnumerableIsNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ((IEnumerable<string>?)null).CheckIsNotNullOrEmpty(TestParamName));
            Assert.That(ex?.ParamName, Is.EqualTo(TestParamName), nameof(ex.ParamName));
        }


        [Test]
        public void CheckIsNotNullOrEmpty_IEnumerableIsEmpty_ThrowsArgumentException()
        {
            IEnumerable<string> collection = new List<string>();

            var ex = Assert.Throws<ArgumentException>(() => collection.CheckIsNotNullOrEmpty(TestParamName));
            Assert.That(ex?.ParamName, Is.EqualTo(TestParamName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain("empty"), nameof(ex.Message));
        }


        [Test]
        public void CheckIsNotNullOrEmpty_IEnumerableHasItem_ReturnParamValue()
        {
            IEnumerable<string> enumerable = new List<string> { "test" };

            var actual = enumerable.CheckIsNotNullOrEmpty(nameof(enumerable));

            Assert.That(actual, Is.EqualTo(enumerable));
        }
        #endregion


        #region ICollection> CheckIsNotNullOrEmpty
        [Test]
        public void CheckIsNotNullOrEmpty_ICollectionIsNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ((ICollection<string>?)null).CheckIsNotNullOrEmpty(TestParamName));
            Assert.That(ex?.ParamName, Is.EqualTo(TestParamName), nameof(ex.ParamName));
        }


        [Test]
        public void CheckIsNotNullOrEmpty_ICollectionIsEmpty_ThrowsArgumentException()
        {
            ICollection<string> collection = new List<string>();

            var ex = Assert.Throws<ArgumentException>(() => collection.CheckIsNotNullOrEmpty(TestParamName));
            Assert.That(ex?.ParamName, Is.EqualTo(TestParamName), nameof(ex.ParamName));
            Assert.That(ex?.Message, Does.Contain("empty"), nameof(ex.Message));
        }


        [Test]
        public void CheckIsNotNullOrEmpty_ICollectionHasItem_ReturnParamValue()
        {
            ICollection<string> collection = new List<string> { "test" };

            var actual = collection.CheckIsNotNullOrEmpty(nameof(collection));

            Assert.That(actual, Is.EqualTo(collection));
        }
        #endregion
    }
}