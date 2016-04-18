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
        public String Key { get; set; }
        [DataMember(Name="name")]
        public String Name { get; set; }
        [DataMember(Name = "emilAddress")]
        public String Email { get; set; }
        [DataMember(Name = "displayName")]
        public String DisplayName { get; set; }
    }
}
