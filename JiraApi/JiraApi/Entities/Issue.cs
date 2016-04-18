using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace JiraApi.Entities
{
    [DataContract]
    public class Issue
    {
        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "fields")]
        public IssueFields Fields { get; set; }

        public bool HasStatus
        {
            get
            {
                return !(Fields == null || Fields.Status == null);
            }
        }

        public bool HasResolution
        {
            get
            {
                return !(Fields == null || Fields.Resolution == null);
            }
        }

        public bool IsStatusReview()
        {
            if (!HasStatus)
            {
                return false;
            }

            return Fields.Status.Name.ToUpperInvariant().Contains("REVIEW");
        }

        public bool IsResolutionFixed()
        {
            if (HasResolution)
            {
                return false;
            }

            return Fields.Resolution.Name.ToUpperInvariant().Contains("FIXED");
        }
    }

    [DataContract]
    public class IssueFields
    {
        [DataMember(Name = "status")]
        public IssueField Status { get; set; }

        [DataMember(Name = "resolution")]
        public IssueField Resolution { get; set; }
    }
}
