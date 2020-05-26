﻿namespace Cloudtoid.Json.Schema
{
    /// <summary>
    /// This is the root element in a Json Schema.
    /// </summary>
    public class JsonSchema : JsonSchemaElement
    {
        public JsonSchema(
            JsonSchemaVersion version,
            JsonSchemaConstraints constraints,
            JsonSchemaMetadata? metadata)
            : base(constraints, metadata)
        {
            Version = version;
        }

        public virtual JsonSchemaVersion Version { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitSchema(this);
    }
}
