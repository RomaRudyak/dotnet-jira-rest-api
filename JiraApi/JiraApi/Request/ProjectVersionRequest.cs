using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace JiraApi.Request
{
    public class ProjectVersionRequest : ProjectRequest
    {
        public ProjectVersionRequest(string keyOrId, HttpMethod method)
            : base(keyOrId, method)
        {

        }

        protected override void ConfigurPath()
        {
            base.ConfigurPath();
            ExtendPath("version");
        }
    }
}
