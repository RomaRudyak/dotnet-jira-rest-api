using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JiraApi.Request;

namespace JiraApi
{
    /// <summary>
    /// Contains logic for commuticatin with JIRA client
    /// </summary>
    public class JiraClient : IDisposable
    {
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
            
            throw new NotImplementedException(string.Format("'{0}' method not implement. Please implement it for farther usage", request.Method.Method));
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

            throw new NotImplementedException(string.Format("'{0}' method not implement. Please implement it for farther usage", request.Method.Method));
        }

        public void Dispose()
        {
            _jiraHttpClient.Dispose();
            _jiraHttpClient = null;
        }

        /// <summary>
        /// Constructs instance
        /// </summary>
        /// <param name="baseUrl">
        /// Configures base sercive url
        /// </param>
        public JiraClient(string baseUrl)
            : this(baseUrl, null, null)
        {

        }

        /// <summary>
        /// Constructs instance
        /// </summary>
        /// <param name="baseUrl">
        /// Configures base sercive url
        /// </param>
        /// <param name="userName">
        /// User login for Basic service authentication
        /// </param>
        /// <param name="password">
        /// User password for Basic service authentication
        /// </param>
        public JiraClient(string baseUrl, string userName, string password)
        {
            _jsonSerializer = JsonSerializer.CreateDefault();
            _jiraHttpClient = new HttpClient();
            _jiraHttpClient.BaseAddress = new Uri(baseUrl);
            _jiraHttpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _jiraHttpClient.DefaultRequestHeaders.Add("X-Atlassian-Token", "nocheck");

            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                var byteArray = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", userName, password));
                _jiraHttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            }
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
        private JsonSerializer _jsonSerializer;
    }
}
