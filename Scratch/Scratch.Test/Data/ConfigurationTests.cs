using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Scratch.Data;
using Scratch.Data.Core;

namespace Scratch.Test.Data
{
    [TestClass]
    public class ConfigurationTests
    {
        #region setup / teardown

        private Configuration _configuration;

        [TestInitialize]
        public void TestSetup()
        {
            _configuration = new Configuration();
        }

        #endregion

        #region Load(IDatabaseSettings connectionStringSettings)

        [TestMethod]
        public void Load_IDatabaseSettings_sets_ExpectedName()
        {
            // arrange
            // see connection string in App.config
            const string expected = "Scratch";
            var connectionStringSettings = MockRepository.GenerateStub<IDatabaseSettings>();
            connectionStringSettings.Messages = new List<string>();

            // act
            _configuration.Load(connectionStringSettings);
            var actual = connectionStringSettings.ExpectedConnectionStringName;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Load_IDatabaseSettings_sets_ExpectedProviderName()
        {
            // arrange
            // see connection string in App.config
            const string expected = "System.Data.SqlClient";
            var connectionStringSettings = MockRepository.GenerateStub<IDatabaseSettings>();
            connectionStringSettings.Messages = new List<string>();

            // act
            _configuration.Load(connectionStringSettings);
            var actual = connectionStringSettings.ExpectedConnectionStringProviderName;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Load_IDatabaseSettings_sets_ActualProviderName()
        {
            // arrange
            // see connection string in App.config
            const string expected = "System.Data.SqlClient";
            var connectionStringSettings = MockRepository.GenerateStub<IDatabaseSettings>();
            connectionStringSettings.Messages = new List<string>();

            // act
            _configuration.Load(connectionStringSettings);
            var actual = connectionStringSettings.ActualConnectionStringProviderName;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Load_IDatabaseSettings_sets_ActualConnectionString()
        {
            // arrange
            // see connection string in App.config
            const string expected = "_";
            var connectionStringSettings = MockRepository.GenerateStub<IDatabaseSettings>();
            connectionStringSettings.Messages = new List<string>();

            // act
            _configuration.Load(connectionStringSettings);
            var actual = connectionStringSettings.ActualConnectionString;

            // assert
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
