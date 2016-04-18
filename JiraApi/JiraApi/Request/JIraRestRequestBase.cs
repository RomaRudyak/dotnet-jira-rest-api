using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Request
{
    public abstract class JiraRestRequestBase : RequestBase
    {
        public JiraRestRequestBase(HttpMethod method)
            : base(method)
        {

        }

        protected override void ConfigurPath()
        {
            ExtendPath("rest/api/2");
        }
    }
}
