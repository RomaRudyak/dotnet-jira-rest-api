using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.CustomFields
{
    /// <summary>
    /// Used for serialization to Object with value property
    /// </summary>
    /// <example>
    /// Serializes to:
    /// {
    ///     "value": "your_value"
    /// }
    /// </example>
    public class ObjectValueCustomField : CustomFieldBase
    {
        public ObjectValueCustomField(string id, string value)
            : base(id, new Dictionary<string, string>{{"value", value}})
        {

        }
    }
}
