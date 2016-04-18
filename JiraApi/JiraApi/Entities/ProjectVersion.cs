using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Entities
{
    [DataContract]
    public class ProjectVersion
    {
        [DataMember(Name = "id")]
        public String Id { get; set; }
        [DataMember(Name = "name")]
        public String Name { get; set; }
        [DataMember(Name = "archived")]
        public bool Archived { get; set; }
        [DataMember(Name = "released")]
        public bool Released { get; set; }
    }
}
