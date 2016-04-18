using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.CustomFields
{
    /// <summary>
    /// Contains decaration for JIRA custom fields.
    /// Used for contracting JSON request to JIRA
    /// </summary>
    public abstract class CustomFieldBase
    {
        /// <summary>
        /// Returns full custom field.
        /// Example: "customfield_10001"
        /// </summary>
        public String FullName { get; private set; }
        /// <summary>
        /// Custom field Id
        /// </summary>
        public String Id { get; private set; }

        public override string ToString()
        {
            return _serializedObject ?? (_serializedObject = JsonConvert.SerializeObject(_value));
        }

        protected CustomFieldBase(String id, dynamic value)
        {
            Id = id;
            FullName = String.Concat("customfield_", Id);
            _value = value;
        }

        private readonly dynamic _value;
        private string _serializedObject;
    }
}
