using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Authorization
{
    public abstract class AuthorizationBase : AuthenticationHeaderValue
    {
        public AuthorizationBase(String schema, String param)
            : base (schema, param)
        {

        }
    }
}
