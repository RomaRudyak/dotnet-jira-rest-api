using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiraApi.Authorization;
using System.Text;

namespace JiraApi.Tests.Authorization
{
    [TestClass]
    public class BasicAuthenticationTest
    {
        [TestMethod]
        public void SchemeIsNotNullTest()
        {
            var userName = "user";
            var password = "password";

            var header = new BasicAuthentication(userName, password);

            Assert.IsNotNull(header.Scheme);
        }

        [TestMethod]
        public void SchemeIsBasicTest()
        {
            var userName = "user";
            var password = "password";

            var header = new BasicAuthentication(userName, password);

            Assert.AreEqual("Basic", header.Scheme);
        }

        [TestMethod]
        public void ParameterIsNotNullTest()
        {
            var userName = "user";
            var password = "password";

            var header = new BasicAuthentication(userName, password);

            Assert.IsNotNull(header.Parameter);
        }

        [TestMethod]
        public void ParameterGeneratedInBase64SuccessfullyTest()
        {
            var userName = "user";
            var password = "password";

            var formatedString = String.Format("{0}:{1}", userName, password);
            var stringBytes = Encoding.UTF8.GetBytes(formatedString);
            var base64string = Convert.ToBase64String(stringBytes);

            var header = new BasicAuthentication(userName, password);

            Assert.AreEqual(base64string, header.Parameter);
        }

        [TestMethod]
        public void BasicAuthentificationStringTest()
        {
            var userName = "user";
            var password = "password";

            var formatedString = String.Format("{0}:{1}", userName, password);
            var stringBytes = Encoding.UTF8.GetBytes(formatedString);
            var base64string = Convert.ToBase64String(stringBytes);
            var expected = String.Format("Basic {0}", base64string);

            var header = new BasicAuthentication(userName, password);

            Assert.AreEqual(expected, header.ToString());
        }
    }
}
