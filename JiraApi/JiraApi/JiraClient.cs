using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JiraApi.Request;
using JiraApi.Authorization;
using System.Net.Http.Headers;

namespace JiraApi
{
    /// <summary>
    /// Contains logic for commuticatin with JIRA client
    /// </summary>
    public class JiraClient : IDisposable
    {
        public AuthenticationHeaderValue Authorization
        {
            get { return _jiraHttpClient.DefaultRequestHeaders.Authorization; }
            set
            {
                _jiraHttpClient.DefaultRequestHeaders.Authorization = value;
            }
        }

        /// <summary>
        /// Execute request acoordinatly to reques configuration taked in
        /// </summary>
        /// <typeparam name="TResult">
        /// Type of result object from se service. 
        /// Object must declare properties with DataMemberAttribute
        /// </typeparam>
        /// <param name="request">
        /// Request configuration which will be performed.
        /// How to Configure Request refer to RequstBase
        /// </param>
        /// <returns>
        /// Task of Deserialized Object of TResult type 
        /// </returns>
        public async Task<TResult> DoRequestAsync<TResult>(RequestBase request)
        {
            if (request.Method.Equals(HttpMethod.Get))
            {
                return await GetAsync<TResult>(request);
            }

            if (request.Method.Equals(HttpMethod.Post))
            {
                return await PostAsync<TResult>(request);
            }
            
            throw new NotImplementedException(String.Format("'{0}' method not implement. Please implement it for farther usage", request.Method.Method));
        }

        /// <summary>
        /// Execute request acoordinatly to reques configuration taked in
        /// </summary>
        /// <param name="request">
        /// Request configuration which will be performed.
        /// How to Configure Request refer to RequstBase
        /// </param>
        /// <returns>Task of request execution</returns>
        public async Task DoRequestAsync(RequestBase request)
        {
            if (request.Method.Equals(HttpMethod.Post))
            {
                await PostAsync(request);
                return;
            }

            throw new NotImplementedException(String.Format("'{0}' method not implement. Please implement it for farther usage", request.Method.Method));
        }

        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Constructs instance
        /// </summary>
        /// <param name="baseUrl">
        /// Configures base sercive url
        /// </param>
        public JiraClient(String baseUrl)
        {
            _jiraHttpClient = new HttpClient();
            _jiraHttpClient.BaseAddress = new Uri(baseUrl);

            _jiraHttpClient.DefaultRequestHeaders.Add("X-Atlassian-Token", "nocheck");
            _jiraHttpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _jiraHttpClient.Dispose();
                _jiraHttpClient = null;
            }
            _disposed = true;
        }

        private async Task<TResult> GetAsync<TResult>(RequestBase request)
        {
            var responce = await _jiraHttpClient.GetAsync(request.BuildPath());
            responce.EnsureSuccessStatusCode();
            return await responce.Content.ReadAsAsync<TResult>();;
        }

        private async Task PostAsync(RequestBase request)
        {
            await PostAsyncInternal(request);
        }

        private async Task<TResult> PostAsync<TResult>(RequestBase request)
        {
            var responce = await PostAsyncInternal(request);
            return await responce.Content.ReadAsAsync<TResult>();
        }

        private async Task<HttpResponseMessage> PostAsyncInternal(RequestBase request)
        {
            var requstBody = request.BuildBody();
            var path = request.BuildPath();
            var responce = await _jiraHttpClient.PostAsync(path, requstBody);
            return responce.EnsureSuccessStatusCode();
        }

        private HttpClient _jiraHttpClient;
        private bool _disposed = false;
    }
}
