namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;
    using static Contract;

    public abstract class JsonSchemaElement
    {
        public JsonSchemaElement(
            IReadOnlyList<JsonSchemaConstraint> constraints,
            JsonSchemaMetadata? metadata)
        {
            Constraints = CheckValue(constraints, nameof(constraints));
            Metadata = metadata;
        }

        public virtual IReadOnlyList<JsonSchemaConstraint> Constraints { get; }

        public virtual JsonSchemaMetadata? Metadata { get; }

        protected internal abstract void Accept(JsonSchemaVisitor visitor);
    }
}
