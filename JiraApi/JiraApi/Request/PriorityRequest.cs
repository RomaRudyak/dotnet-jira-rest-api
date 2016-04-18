using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Request
{
    public class PriorityRequest : RequestBase
    {
        public PriorityRequest(HttpMethod method)
            :this(null, method)
        {

        }

        public PriorityRequest(string keyOrId, HttpMethod method)
            : base(method)
        {
            _keyOrId = keyOrId;
        }

        protected override void ConfigurPath()
        {
            ExtendPath("rest/api/2/priority");
            if (!string.IsNullOrWhiteSpace(_keyOrId))
            {
                ExtendPath(_keyOrId);
            }
        }

        private string _keyOrId;
    }
}
