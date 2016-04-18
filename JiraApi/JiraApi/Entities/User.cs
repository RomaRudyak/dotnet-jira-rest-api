using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Entities
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "key")]
        public string Key { get; set; }
        [DataMember(Name="name")]
        public string Name { get; set; }
        [DataMember(Name = "emilAddress")]
        public string Email { get; set; }
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }
    }
}
