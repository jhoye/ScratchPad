using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scratch.Test
{
    [TestClass]
    public class DependentBaseTests
    {
        #region setup / teardown

        private class DependentMock : DependentBase
        {
            public new Components Components
            {
                get
                {
                    return base.Components;
                }
            }
        }

        private DependentMock _dependent;

        [TestInitialize]
        public void TestSetup()
        {
            _dependent = new DependentMock();
        }

        #endregion

        [TestMethod]
        public void Components_returns_instance()
        {
            // arrange
            var expected = new Components();
            Components.Access = () => expected;

            // act
            var actual = _dependent.Components;

            // assert
            Assert.AreSame(expected, actual);
        }
    }
}
