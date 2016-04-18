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
        public String ProjectKey { get; set; }
        public String Summary { get; set; }
        public String Description { get; set; }
        public String TypeId { get; set; }
        public String PriorityId { get; set; }
        public String[] Versions { get; set; }
        public String Reporter { get; set; }

        public IEnumerable<CustomFieldBase> CustomFields { get; set; }

        public IssueRequest(HttpMethod method)
            : this(null, method)
        {

        }

        public IssueRequest(String keyOrId, HttpMethod method)
            : base(keyOrId, method)
        {
            Versions = new String[0];
            CustomFields = Enumerable.Empty<CustomFieldBase>();
        }

        protected override void ConfigurParams()
        {
            ExtendParams("fields=status,resolution");
        }

        protected override void ConfigurBody(Dictionary<String, dynamic> body)
        {
            var updateSection = new Dictionary<String, dynamic>();
            var fieldsSection = new Dictionary<String, dynamic>();

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

        protected virtual void ConfigureBodyFieldsSection(Dictionary<String, dynamic> fieldsSection)
        {
            if (!String.IsNullOrWhiteSpace(ProjectKey))
            {
                fieldsSection.Add("project", new Dictionary<String, String>
                {
                    { "key", ProjectKey }
                });
            }
            if (!String.IsNullOrWhiteSpace(TypeId))
            {
                fieldsSection.Add("issuetype", new Dictionary<String, String>
                {
                    { "id", TypeId }
                });
            }

            if (!String.IsNullOrWhiteSpace(Summary))
            {
                fieldsSection.Add("summary", Summary);
            }

            if (!String.IsNullOrWhiteSpace(Description))
            {
                fieldsSection.Add("description", Description);
            }

            if (!String.IsNullOrWhiteSpace(PriorityId))
            {
                fieldsSection.Add("priority", new Dictionary<String, String>
                {
                    { "id", PriorityId }
                });
            }

            if (Versions.Length > 0)
            {
                fieldsSection.Add("versions", Versions.Select(x=> new Dictionary<String, String> { { "id", x } }).ToArray());
            }

            if (!String.IsNullOrWhiteSpace(Reporter))
            {
                fieldsSection.Add("reporter", new Dictionary<String, String>
                {
                    { "name", Reporter }
                });
            }
            
            foreach (var customfield in CustomFields)
            {
                fieldsSection.Add(customfield.FullName, customfield.Value);
            }
        }

        protected virtual void ConfigureBodyUpdateSection(Dictionary<String, dynamic> updateSection)
        {
            // Add worklog initialization here


        }
    }
}
