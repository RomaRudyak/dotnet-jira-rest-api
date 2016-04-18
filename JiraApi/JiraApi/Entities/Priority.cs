using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Entities
{
    [DataContract]
    public class Priority
    {
        [DataMember(Name="id")]
        public string Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "statusColor")]
        public string StatusColor { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}
