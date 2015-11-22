using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Scratch.ConfigurationSections;
using Scratch.Settings;

namespace Scratch.Test
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

        #region MailSettings

        [TestMethod]
        public void MailSettings_returns_Mail_object()
        {
            // arrange
            // see "mail" section in App.Config
            var expected = typeof(Mail);

            // act
            var actual = _configuration.MailSettings.GetType();

            // assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Load(IConnectionStringSettings connectionStringSettings)

        [TestMethod]
        public void Load_IConnectionStringSettings_sets_ExpectedName()
        {
            // arrange
            // see connection string in App.config
            const string expected = "Scratch";
            var connectionStringSettings = MockRepository.GenerateStub<IConnectionString>();

            // act
            _configuration.Load(connectionStringSettings);
            var actual = connectionStringSettings.ExpectedName;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Load_IConnectionStringSettings_sets_ExpectedProviderName()
        {
            // arrange
            // see connection string in App.config
            const string expected = "System.Data.SqlClient";
            var connectionStringSettings = MockRepository.GenerateStub<IConnectionString>();

            // act
            _configuration.Load(connectionStringSettings);
            var actual = connectionStringSettings.ExpectedProviderName;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Load_IConnectionStringSettings_sets_ActualProviderName()
        {
            // arrange
            // see connection string in App.config
            const string expected = "System.Data.SqlClient";
            var connectionStringSettings = MockRepository.GenerateStub<IConnectionString>();

            // act
            _configuration.Load(connectionStringSettings);
            var actual = connectionStringSettings.ActualProviderName;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Load_IConnectionStringSettings_sets_ActualConnectionString()
        {
            // arrange
            // see connection string in App.config
            const string expected = "_";
            var connectionStringSettings = MockRepository.GenerateStub<IConnectionString>();

            // act
            _configuration.Load(connectionStringSettings);
            var actual = connectionStringSettings.ActualConnectionString;

            // assert
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
