using Newtonsoft.Json.Linq;
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

        internal override HttpContent BuildHttpBodyContent()
        {
            var body = new Dictionary<String, dynamic>();
            ConfigurBody(body);
            var data = JObject.FromObject(body).ToString();
            return new StringContent(data, Encoding.UTF8, "application/json");
        }

        protected override void ConfigurPath()
        {
            ExtendPath("rest/api/2");
        }

        /// <summary>
        /// Cofigures request JSON body.
        /// </summary>
        /// <param name="body">
        /// Dictionary tha be converted into cvalified representation of JSON String.
        /// </param>
        /// <example>
        /// var t = new Dictionary&lt;String, dynamic&gt; 
        /// {
        ///     {"id", "1"}
        /// }
        /// Reults in:
        /// {
        ///     "id": "1"
        /// }
        /// 
        /// 
        /// var t = new Dictionary&lt;String, dynamic&gt; 
        /// {
        ///     {
        ///         "innerObj", new Dictionary&lt;String, dynamic&gt; 
        ///         {
        ///             { "name", "SomeName" }
        ///         }
        ///     }
        /// }
        /// Reults in:
        /// {
        ///     "innerObj": {
        ///         "name": "SomeName"
        ///     }
        /// }
        /// </example>
        protected virtual void ConfigurBody(Dictionary<String, dynamic> body) { }

    }
}
