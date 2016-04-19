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
        public IssueTransactionRequest(String keyOrId, HttpMethod method)
            : base(keyOrId, method)
        {
        }

        public String TransitionId { get; set; }
        public String Comment { get; set; }
        public String ResolutionId { get; set; }

        protected override void ConfigurPath()
        {
            base.ConfigurPath();
            ExtendPath("transitions");
        }

        protected override void ConfigurParams()
        {
            ExtendParams("expand", "transitions.fields");
        }

        protected override void ConfigurBody(Dictionary<String, dynamic> body)
        {
            base.ConfigurBody(body);
        
            body.Add("transition", new Dictionary<String, String>
                {
                    { "id", TransitionId }
                });

            body.Add("resolution", new Dictionary<String, String>
                {
                    { "id", ResolutionId }
                });
        }

        protected override void ConfigureBodyUpdateSection(Dictionary<String, dynamic> updateSection)
        {
            if (!String.IsNullOrWhiteSpace(Comment))
            {
                updateSection.Add("comment", new[]
                {
                    new Dictionary<String, dynamic>
                    {
                        { "add", new Dictionary<String,String> { { "body", Comment } } }
                    }
                });
            }

            foreach (var customfield in CustomFields)
            {
                updateSection.Add(customfield.FullName, new[]
                {
                    new Dictionary<String, String>
                    {
                        { "set", customfield.Value }
                    }
                });
            }
        }
    }
}
