using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Request
{
    public class ProjectRequest : RequestBase
    {
        public ProjectRequest(HttpMethod method)
            : this(null, method)
        {

        }

        public ProjectRequest(string keyOrId, HttpMethod method)
            : base(method)
        {
            _keyOrId = keyOrId;
        }

        protected override void ConfigurPath()
        {
            ExtendPath("rest/api/2/project");
            if (!string.IsNullOrWhiteSpace(_keyOrId))
            {
                ExtendPath(_keyOrId);
            }
        }

        private string _keyOrId;
    }
}
