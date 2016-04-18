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
        public String Body { get; set; }

        public IssueCommentRequest(String idOrKey, HttpMethod method)
            :base(idOrKey, method)
        {

        }

        protected override void ConfigurPath()
        {
            base.ConfigurPath();
            ExtendPath("comment");
        }

        protected override void ConfigurBody(Dictionary<String, dynamic> body)
        {
            body.Add("body", Body);
        }
    }
}
