using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scratch.ConfigurationSections;

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
    }
}
