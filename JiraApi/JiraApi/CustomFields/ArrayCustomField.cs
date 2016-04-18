using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.CustomFields
{
    /// <summary>
    /// Used for serialization array for value
    /// </summary>
    /// /// <example>
    /// Serializes to:
    /// [ "your_value1", "your_value2" ... "your_valueN" ]
    /// </example>
    public class ArrayCustomField : CustomFieldBase
    {
        public ArrayCustomField(string id, string[] value)
            : base(id, value)
        {

        }
    }
}
