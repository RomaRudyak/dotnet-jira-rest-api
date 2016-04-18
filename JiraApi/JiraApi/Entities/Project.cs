using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Entities
{
    [DataContract]
    public class Project
    {
        [DataMember(Name = "id")]
        public String Id { get; set; }
        [DataMember(Name = "key")]
        public String Key { get; set; }
        [DataMember(Name = "name")]
        public String Name { get; set; }
    }

    [DataContract]
    public class VersionedProject : Project
    {
        [DataMember(Name = "versions")]
        public List<ProjectVersion> Versions { get; set; }

        public VersionedProject()
        {
            Versions = new List<ProjectVersion>();
        }
    }

    [DataContract]
    public class IssueTypedProject : Project
    {
        [DataMember(Name = "issuetypes")]
        public List<IssueType> IssueTypes { get; set; }

        public IssueTypedProject()
        {
            IssueTypes = new List<IssueType>();
        }
    }
}
