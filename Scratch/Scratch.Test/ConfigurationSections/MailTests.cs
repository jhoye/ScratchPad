using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scratch.ConfigurationSections;

namespace Scratch.Test.ConfigurationSections
{
    [TestClass]
    public class MailTests
    {
        #region setup / teardown

        private Mail _mail;

        [TestInitialize]
        public void TestSetup()
        {
            _mail = (Mail)(ConfigurationManager.GetSection("mail"));
        }

        #endregion

        [TestMethod]
        public void DefaultSenderAddress_returns_setting()
        {
            // arrange
            // see "mail" section in App.Config
            const string expected = "_@_._";

            // act
            var actual = _mail.DefaultSenderAddress;

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
