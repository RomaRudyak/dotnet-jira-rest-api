using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Request
{
    /// <summary>
    /// Contains all necessary configurations for request performance
    /// </summary>
    public abstract class RequestBase
    {
        /// <summary>
        /// Returns request method type
        /// </summary>
        public HttpMethod Method { get; private set; }

        /// <summary>
        /// Required initialization params
        /// </summary>
        /// <param name="method">
        /// Request method type
        /// </param>
        protected RequestBase(HttpMethod method)
        {
            Method = method;
            _pathBuilder = new StringBuilder();
            _paramsBuilder = new StringBuilder();
        }

        /// <summary>
        /// Used for building path of the request
        /// </summary>
        /// <returns>
        /// Returns request path part.
        /// </returns>
#if UNITTESTS
        public
#else
        internal
#endif
            String BuildPath()
        {
            ConfigurPath();
            ConfigurParams();
            if (_paramsBuilder.Length == 0)
            {
                return _pathBuilder.ToString();
            }
            return String.Concat(_pathBuilder.ToString(), "?", _paramsBuilder.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Returns HttpContent for request body.
        /// By default it is StringContent with 'application/json' mimetype
        /// </returns>
        internal HttpContent BuildBody()
        {
            return CreateHttpContent();
        }

        /// <summary>
        /// Creates HttpContent for body reques.
        /// Default creates StringContent with 'application/json' mimetype, 
        /// but can be overriden for other Content types
        /// </summary>
        /// <returns>
        /// HttpContent
        /// </returns>
        protected virtual HttpContent CreateHttpContent()
        {
            var body = new Dictionary<String, dynamic>();
            ConfigurBody(body);
            var data = JObject.FromObject(body).ToString();
            return new StringContent(data, Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Required for implementation.
        /// In this method use ExtendPath method for extending request path.
        /// </summary>
        /// <example>
        /// 1. ExtendPath("/rest/apiaction");
        /// 
        /// 2. ExtendPath("rest/apiaction");
        /// 
        /// 3. ExtendPath("rest");
        ///    ExtendPath("apiaction");
        /// </example>
        protected abstract void ConfigurPath();

        /// <summary>
        /// This method configures asitional request path params
        /// In this method use ExtendParams method for extending request path.
        /// </summary>
        protected virtual void ConfigurParams() { }

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

        protected RequestBase ExtendPath(String pathPart)
        {
            if (!pathPart.StartsWith("/"))
            {
                _pathBuilder.Append("/");                
            }
            _pathBuilder.Append(pathPart);
            return this;
        }

        protected RequestBase ExtendParams(String paramsPartName, String paramsPartValue)
        {
            _paramsBuilder.Append(paramsPartName);
            _paramsBuilder.Append("=");
            _paramsBuilder.Append(paramsPartValue);
            _paramsBuilder.Append("&");
            return this;
        }
        
        protected RequestBase ExtendParams(String paramsPart)
        {
            _paramsBuilder.Append(paramsPart);
            _paramsBuilder.Append("&");
            return this;
        }
        
        private StringBuilder _pathBuilder;
        private StringBuilder _paramsBuilder;
    }
}
