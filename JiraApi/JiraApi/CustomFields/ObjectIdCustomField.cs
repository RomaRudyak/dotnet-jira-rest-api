using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.CustomFields
{
    /// <summary>
    /// Used for serialization to Object with id property
    /// </summary>
    /// <example>
    /// Serializes to:
    /// {
    ///     "id": "your_value"
    /// }
    /// </example>
    public class ObjectIdCustomField : CustomFieldBase
    {
        public ObjectIdCustomField(String id, String value)
            : base(id, new Dictionary<String, String>{{"id", value}})
        {

        }
    }
}
