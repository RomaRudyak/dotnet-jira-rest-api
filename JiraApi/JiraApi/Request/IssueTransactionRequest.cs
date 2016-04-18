using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Request
{
    public class IssueTransactionRequest : IssueRequest
    {
        public IssueTransactionRequest(string keyOrId, HttpMethod method)
            : base(keyOrId, method)
        {
        }

        public string TransitionId { get; set; }
        public string Comment { get; set; }
        public string ResolutionId { get; set; }

        protected override void ConfigurPath()
        {
            base.ConfigurPath();
            ExtendPath("transitions");
        }

        protected override void ConfigurParams()
        {
            ExtendParams("expand=transitions.fields");
        }

        protected override void ConfigurBody(Dictionary<string, dynamic> body)
        {
            base.ConfigurBody(body);
        
            body.Add("transition", new Dictionary<string, string>
                {
                    { "id", TransitionId }
                });

            body.Add("resolution", new Dictionary<string, string>
                {
                    { "id", ResolutionId }
                });
        }

        protected override void ConfigureBodyUpdateSection(Dictionary<string, dynamic> updateSection)
        {
            if (!string.IsNullOrWhiteSpace(Comment))
            {
                updateSection.Add("comment", new[]
                {
                    new Dictionary<string, dynamic>
                    {
                        { "add", new Dictionary<string,string> { { "body", Comment } } }
                    }
                });
            }

            foreach (var customfield in CustomFields)
            {
                updateSection.Add(customfield.FullName, new[]
                {
                    new Dictionary<string, dynamic>
                    {
                        { "set", customfield.Value }
                    }
                });
            }
        }
    }
}
