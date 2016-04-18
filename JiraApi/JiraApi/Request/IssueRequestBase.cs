using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Request
{
    public class IssueRequestBase : RequestBase
    {
        public IssueRequestBase(String keyOrId, HttpMethod method)
            : base(method)
        {
            _keyOrId = keyOrId;
        }

        protected override void ConfigurPath()
        {
            ExtendPath("rest/api/2/issue");
            if (!String.IsNullOrWhiteSpace(_keyOrId))
            {
                ExtendPath(_keyOrId);
            }
        }

        private String _keyOrId;
    }
}
