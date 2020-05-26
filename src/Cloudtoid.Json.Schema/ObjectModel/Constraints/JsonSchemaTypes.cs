namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;
    using static Contract;

    public class JsonSchemaTypes : JsonSchemaConstraint
    {
        public JsonSchemaTypes(IReadOnlyList<JsonSchemaDataType> types)
        {
            Types = CheckNonEmpty(types, nameof(types));
        }

        public JsonSchemaTypes(params JsonSchemaDataType[] types)
        {
            Types = CheckNonEmpty(types, nameof(types));
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
