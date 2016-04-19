using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiraApi.Request;
using System.Net.Http;

namespace JiraApi.Tests.Request
{
    [TestClass]
    public class PriorityRequestTests
    {
        [TestMethod]
        public void PriorityApiPathTest()
        {
            var expectedPath = "/rest/api/2/priority";

            var request = new PriorityRequest(HttpMethod.Get);

            var path = request.BuildPath();

            Assert.AreEqual(expectedPath, path);
        }

        [TestMethod]
        public void ProjectApiPathWithKeyOrIdTest()
        {
            var expectedPath = "/rest/api/2/priority/TESTPRIORITY";
            var keyOrId = "TESTPRIORITY";

            var request = new PriorityRequest(keyOrId, HttpMethod.Get);

            var path = request.BuildPath();

            Assert.AreEqual(expectedPath, path);
        }
    }
}
