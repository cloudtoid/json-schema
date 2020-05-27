namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;
    using static Contract;

    /// <summary>
    /// Provides type validation.
    /// An instance validates if and only if the instance is of any of the types listed here.
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
            : this(new[] { type })
        {
        }

        public virtual IReadOnlyList<JsonSchemaDataType> Types { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitTypes(this);
    }
}
