using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiraApi.Request;
using System.Net.Http;

namespace JiraApi.Tests.Request
{
    [TestClass]
    public class ProjectRequestTests
    {
        [TestMethod]
        public void ProjectApiPathTest()
        {
            var expectedPath = "/rest/api/2/project";

            var request = new ProjectRequest(HttpMethod.Get);

            var path = request.BuildPath();

            Assert.AreEqual(expectedPath, path);
        }

        [TestMethod]
        public void ProjectApiPathWithKeyOrIdTest()
        {
            var expectedPath = "/rest/api/2/project/TESTPROJECT";
            var keyOrId = "TESTPROJECT";

            var request = new ProjectRequest(keyOrId, HttpMethod.Get);

            var path = request.BuildPath();

            Assert.AreEqual(expectedPath, path);
        }
    }
}
