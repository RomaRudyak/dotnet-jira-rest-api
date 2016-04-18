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
        public String[] Ids { get; set; }
        public String[] Keys { get; set; }

        public CreateIssueMetaRequest(HttpMethod method)
            : base(null, method)
        {
            Ids = new String[0];
            Keys = new String[0];
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
                ExtendParams("projectIds", String.Join(",", Ids));
            }

            if (!isKeysEmpty)
            {
                ExtendParams("projectKeys", String.Join(",", Keys));
            }
        }
    }
}
