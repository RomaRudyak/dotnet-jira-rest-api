using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JiraApi.CustomFields;
using JiraApi.Entities;

namespace JiraApi.Request
{
    public class IssueRequest : IssueRequestBase
    {
        public string ProjectKey { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string TypeId { get; set; }
        public string PriorityId { get; set; }
        public string[] Versions { get; set; }
        public string Reporter { get; set; }

        public IEnumerable<CustomFieldBase> CustomFields { get; set; }

        public IssueRequest(HttpMethod method)
            : this(null, method)
        {

        }

        public IssueRequest(string keyOrId, HttpMethod method)
            : base(keyOrId, method)
        {
            Versions = new string[0];
            CustomFields = Enumerable.Empty<CustomFieldBase>();
        }

        protected override void ConfigurParams()
        {
            ExtendParams("fields=status,resolution");
        }

        protected override void ConfigurBody(Dictionary<string, dynamic> body)
        {
            var updateSection = new Dictionary<string, dynamic>();
            var fieldsSection = new Dictionary<string, dynamic>();

            ConfigureBodyUpdateSection(updateSection);
            ConfigureBodyFieldsSection(fieldsSection);

            if (updateSection.Keys.Count > 0)
            {
                body.Add("update", updateSection);
            }

            if (fieldsSection.Keys.Count > 0)
            {
                body.Add("fields", fieldsSection);
            }
        }

        protected virtual void ConfigureBodyFieldsSection(Dictionary<string, dynamic> fieldsSection)
        {
            if (!string.IsNullOrWhiteSpace(ProjectKey))
            {
                fieldsSection.Add("project", new Dictionary<string, string>
                {
                    { "key", ProjectKey }
                });
            }
            if (!string.IsNullOrWhiteSpace(TypeId))
            {
                fieldsSection.Add("issuetype", new Dictionary<string, string>
                {
                    { "id", TypeId }
                });
            }

            if (!string.IsNullOrWhiteSpace(Summary))
            {
                fieldsSection.Add("summary", Summary);
            }

            if (!string.IsNullOrWhiteSpace(Description))
            {
                fieldsSection.Add("description", Description);
            }

            if (!string.IsNullOrWhiteSpace(PriorityId))
            {
                fieldsSection.Add("priority", new Dictionary<string, string>
                {
                    { "id", PriorityId }
                });
            }

            if (Versions.Length > 0)
            {
                fieldsSection.Add("versions", Versions.Select(x=> new Dictionary<string, string> { { "id", x } }).ToArray());
            }

            if (!string.IsNullOrWhiteSpace(Reporter))
            {
                fieldsSection.Add("reporter", new Dictionary<string, string>
                {
                    { "name", Reporter }
                });
            }
            
            foreach (var customfield in CustomFields)
            {
                fieldsSection.Add(customfield.FullName, customfield.Value);
            }
        }

        protected virtual void ConfigureBodyUpdateSection(Dictionary<string, dynamic> updateSection)
        {
            // Add worklog initialization here


        }
    }
}
