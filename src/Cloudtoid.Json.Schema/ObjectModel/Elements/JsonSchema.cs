namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    /// <summary>
    /// This is the root element in a Json Schema.
    /// </summary>
    public class JsonSchema : JsonSchemaElement
    {
        public JsonSchema(
            JsonSchemaVersion version,
            IReadOnlyList<JsonSchemaConstraint> constraints,
            JsonSchemaMetadata? metadata)
            : base(constraints, metadata)
        {
            Version = version;
        }

        public JsonSchema(
            IReadOnlyList<JsonSchemaConstraint> constraints,
            JsonSchemaMetadata? metadata)
            : this(JsonSchemaVersionLookup.LatestSupportedVersion, constraints, metadata)
        {
        }

        public virtual JsonSchemaVersion Version { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitSchema(this);
    }
}
