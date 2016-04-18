using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Request
{
    public class CreateIssueMetaRequest : IssueRequestBase
    {
        public string[] Ids { get; set; }
        public string[] Keys { get; set; }

        public CreateIssueMetaRequest(HttpMethod method)
            : base(null, method)
        {
            Ids = new string[0];
            Keys = new string[0];
        }

        protected override void ConfigurPath()
        {
            base.ConfigurPath();
            ExtendPath("createmeta");
        }

        protected override void ConfigurParams()
        {
            var isIdsEmpty = Ids.Length == 0;
            var isKeysEmpty = Keys.Length == 0;

            if (!isIdsEmpty)
            {
                ExtendParams("projectIds", string.Join(",", Ids));
            }

            if (!isKeysEmpty)
            {
                ExtendParams("projectKeys", string.Join(",", Keys));
            }
        }
    }
}
