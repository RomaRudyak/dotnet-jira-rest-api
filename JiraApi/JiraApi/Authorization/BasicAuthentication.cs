using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Authorization
{
    public class BasicAuthentication : AuthenticationHeaderValue
    {
        public BasicAuthentication(String user, String password)
            : base ("Basic", GetParam(user, password))
        {
            
        }

        private static String GetParam(String user, String password)
        {
            var byteArray = Encoding.UTF8.GetBytes(String.Format("{0}:{1}", user, password));
            return Convert.ToBase64String(byteArray);
        }
    }
}
