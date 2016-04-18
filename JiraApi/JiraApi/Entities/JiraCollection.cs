using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Entities
{
    [DataContract]
    public class JiraCollection<T>
    {
        [DataMember(Name="values")]
        public List<T> Items { get; set; }
        [DataMember(Name = "total")]
        public int Total { get; set; }
    }
}
