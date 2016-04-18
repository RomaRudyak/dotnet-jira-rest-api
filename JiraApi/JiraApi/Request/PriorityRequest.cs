using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Request
{
    public class PriorityRequest : JiraRestRequestBase
    {
        public PriorityRequest(HttpMethod method)
            :this(null, method)
        {

        }

        public PriorityRequest(String keyOrId, HttpMethod method)
            : base(method)
        {
            _keyOrId = keyOrId;
        }

        protected override void ConfigurPath()
        {
            base.ConfigurPath();
            ExtendPath("priority");
            if (!String.IsNullOrWhiteSpace(_keyOrId))
            {
                ExtendPath(_keyOrId);
            }
        }

        private String _keyOrId;
    }
}
