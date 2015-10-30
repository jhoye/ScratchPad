using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Scratch.Data;
using Scratch.ServiceDelegates;

namespace Scratch.Test
{
    [TestClass]
    public class ComponentsTests
    {
        #region setup / teardown

        private Components _components;

        [TestInitialize]
        public void TestSetup()
        {
            _components = new Components();
        }

        #endregion

        [TestMethod]
        public void Cache_gets_and_sets_same_instance()
        {
            // arrange
            var expected = MockRepository.GenerateMock<ICache>();

            // act
            _components.Cache = expected;
            var actual = _components.Cache;

            // assert
            Assert.AreSame(expected, actual);
        }

        [TestMethod]
        public void Configuration_gets_and_sets_same_instance()
        {
            // arrange
            var expected = MockRepository.GenerateMock<IConfiguration>();

            // act
            _components.Configuration = expected;
            var actual = _components.Configuration;

            // assert
            Assert.AreSame(expected, actual);
        }

        [TestMethod]
        public void Users_gets_and_sets_same_instance()
        {
            // arrange
            var expected = MockRepository.GenerateMock<IUsers>();

            // act
            _components.Users = expected;
            var actual = _components.Users;

            // assert
            Assert.AreSame(expected, actual);
        }

        [TestMethod]
        public void Access_gets_and_sets_same_instance()
        {
            // arrange
            Func<Components> expected = () => new Components();

            // act
            Components.Access = expected;
            var actual = Components.Access;

            // assert
            Assert.AreSame(expected, actual);
        }
    }
}
