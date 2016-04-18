using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Request
{
    public class IssueCommentRequest : IssueRequestBase
    {
        public string Body { get; set; }

        public IssueCommentRequest(string idOrKey, HttpMethod method)
            :base(idOrKey, method)
        {

        }

        protected override void ConfigurPath()
        {
            base.ConfigurPath();
            ExtendPath("comment");
        }

        protected override void ConfigurBody(Dictionary<string, dynamic> body)
        {
            body.Add("body", Body);
        }
    }
}
