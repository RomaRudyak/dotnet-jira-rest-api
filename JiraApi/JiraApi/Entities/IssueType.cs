using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Entities
{
    [DataContract]
    public class IssueType
    {
        [DataMember(Name="id")]
        public String Id { get; set; }
        [DataMember(Name = "name")]
        public String Name { get; set; }
        [DataMember(Name = "description")]
        public String Description { get; set; }
        [DataMember(Name = "subtask")]
        public bool IsSubtask { get; set; }

    }
}
