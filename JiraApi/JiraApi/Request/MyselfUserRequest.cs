using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Request
{
    public class MyselfUserRequest : RequestBase
    {
        public MyselfUserRequest(HttpMethod method)
            : base(method)
        {

        }

        protected override void ConfigurPath()
        {
            ExtendPath("rest/api/2/myself");
        }
    }
}
