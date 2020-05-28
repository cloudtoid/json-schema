namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections.Generic;
    using static Contract;

    /// <summary>
    /// Provides data type validation.
    /// An instance is valid if and only if the instance is of any of the types listed here.
    /// </summary>
    public class JsonSchemaTypes : JsonSchemaConstraint
    {
        public JsonSchemaTypes(IReadOnlyList<JsonSchemaDataType> types)
        {
            Types = CheckNonEmpty(types, nameof(types));
        }

        public JsonSchemaTypes(params JsonSchemaDataType[] types)
            : this((IReadOnlyList<JsonSchemaDataType>)types)
        {
        }

        public JsonSchemaTypes(JsonSchemaDataType type)
            : this(new ValueList<JsonSchemaDataType>(type))
        {
        }

        public JsonSchemaTypes()
        {
            Types = Array.Empty<JsonSchemaDataType>();
        }

        public virtual IReadOnlyList<JsonSchemaDataType> Types { get; set; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitTypes(this);
    }
}
