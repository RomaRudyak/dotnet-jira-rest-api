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
        /// Used for creating Http Body Content which 
        /// will be send to the servrer with request
        /// </summary>
        /// <returns>
        /// HttpContent
        /// </returns>
        internal abstract HttpContent BuildHttpBodyContent();

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
            if (_paramsBuilder.Length > 0)
            {
                _paramsBuilder.Append("&");
            }
            _paramsBuilder.Append(paramsPartName);
            _paramsBuilder.Append("=");
            _paramsBuilder.Append(paramsPartValue);
            return this;
        }
        
        private StringBuilder _pathBuilder;
        private StringBuilder _paramsBuilder;
    }
}
