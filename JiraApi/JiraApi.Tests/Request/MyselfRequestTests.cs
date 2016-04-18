using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiraApi.Request;
using System.Net.Http;

namespace JiraApi.Tests.Request
{
    [TestClass]
    public class MyselfRequestTests
    {
        [TestMethod]
        public void MyselfApiPathTest()
        {
            var expectedPath = "/rest/api/2/myself";

            var request = new MyselfRequest(HttpMethod.Get);

            var path = request.BuildPath();

            Assert.AreEqual(expectedPath, path);
        }
    }
}
