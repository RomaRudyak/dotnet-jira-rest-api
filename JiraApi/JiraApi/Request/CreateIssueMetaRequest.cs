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
        public String[] ProjectIds { get; set; }
        public String[] ProjectKeys { get; set; }

        public CreateIssueMetaRequest(HttpMethod method)
            : base(null, method)
        {
            ProjectIds = new String[0];
            ProjectKeys = new String[0];
        }

        protected override void ConfigurPath()
        {
            base.ConfigurPath();
            ExtendPath("createmeta");
        }

        protected override void ConfigurParams()
        {
            var isIdsEmpty = ProjectIds.Length == 0;
            var isKeysEmpty = ProjectKeys.Length == 0;

            if (!isIdsEmpty)
            {
                ExtendParams("projectIds", String.Join(",", ProjectIds));
            }

            if (!isKeysEmpty)
            {
                ExtendParams("projectKeys", String.Join(",", ProjectKeys));
            }
        }
    }
}
