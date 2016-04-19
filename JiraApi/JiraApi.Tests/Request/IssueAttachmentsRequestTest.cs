using JiraApi.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Tests.Request
{
    [TestClass]
    public class IssueAttachmentsRequestTest
    {
        [TestMethod]
        public void IssueAttachmentsApiPathWithKeyOrIdTest()
        {
            var expectedPath = "/rest/api/2/issue/TEST-1324/attachments";
            var key = "TEST-1324";

            var request = new IssueAttachmentsRequest(key, HttpMethod.Get);

            Assert.AreEqual(expectedPath, request.BuildPath());
        }
    }
}
