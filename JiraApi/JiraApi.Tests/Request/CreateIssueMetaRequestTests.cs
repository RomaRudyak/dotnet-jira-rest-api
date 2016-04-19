using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiraApi.Request;
using System.Net.Http;

namespace JiraApi.Tests.Request
{
    [TestClass]
    public class CreateIssueMetaRequestTests
    {
        [TestMethod]
        public void CreateIssueMetaApiPathTest()
        {
            var expectedPath = "/rest/api/2/issue/createmeta";

            var request = new CreateIssueMetaRequest(HttpMethod.Get);

            var path = request.BuildPath();

            Assert.AreEqual(expectedPath, path);
        }

        [TestMethod]
        public void CreateIssueMetaApiPathWithProjectIdsParamTest()
        {
            var expectedPath = "/rest/api/2/issue/createmeta?projectIds=12345,54321";
            var ids = new[] { "12345", "54321" };

            var request = new CreateIssueMetaRequest(HttpMethod.Get)
            {
                ProjectIds = ids
            };

            var path = request.BuildPath();

            Assert.AreEqual(expectedPath, path);
        }

        [TestMethod]
        public void CreateIssueMetaApiPathWithProjectKeysParamTest()
        {
            var expectedPath = "/rest/api/2/issue/createmeta?projectKeys=TESTPROJECT1,TESTPROJECT2";
            var keys = new[] { "TESTPROJECT1", "TESTPROJECT2" };

            var request = new CreateIssueMetaRequest(HttpMethod.Get)
            {
                ProjectKeys = keys
            };

            var path = request.BuildPath();

            Assert.AreEqual(expectedPath, path);
        }

        [TestMethod]
        public void CreateIssueMetaApiPathWithProjectIdsAndProjectKeysParamTest()
        {
            var expectedPath = "/rest/api/2/issue/createmeta?projectIds=12345,54321&projectKeys=TESTPROJECT1,TESTPROJECT2";
            var ids = new[] { "12345", "54321" };
            var keys = new[] { "TESTPROJECT1", "TESTPROJECT2" };

            var request = new CreateIssueMetaRequest(HttpMethod.Get)
            {
                ProjectIds = ids,
                ProjectKeys = keys
            };

            var path = request.BuildPath();

            Assert.AreEqual(expectedPath, path);
        }
    }
}
