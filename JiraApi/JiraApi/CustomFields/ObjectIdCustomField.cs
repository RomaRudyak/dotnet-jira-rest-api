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
        public ObjectIdCustomField(string id, string value)
            : base(id, new Dictionary<string, string>{{"id", value}})
        {

        }
    }
}
