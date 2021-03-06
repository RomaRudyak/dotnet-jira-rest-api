﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.CustomFields
{
    /// <summary>
    /// Used for serialization to String
    /// </summary>
    /// <example>
    /// Serialized to:
    /// "your_value"
    /// </example>
    public class PlainCustomField : CustomFieldBase
    {
        public PlainCustomField(String id, String value)
            : base(id, value)
        {

        }
    }
}
