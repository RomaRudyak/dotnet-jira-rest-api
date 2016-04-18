﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Request
{
    public class MyselfUserRequest : JiraRestRequestBase
    {
        public MyselfUserRequest(HttpMethod method)
            : base(method)
        {

        }

        protected override void ConfigurPath()
        {
            base.ConfigurPath();
            ExtendPath("myself");
        }
    }
}
