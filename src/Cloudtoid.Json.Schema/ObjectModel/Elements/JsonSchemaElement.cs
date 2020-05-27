namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections.Generic;
    using static KeywordsContract;

    public abstract class JsonSchemaElement
    {
        protected JsonSchemaElement(
            Uri? id,
            string? anchor,
            JsonSchemaMetadata? metadata,
            IReadOnlyList<JsonSchemaConstraint>? constraints)
        {
            Id = id;
            Anchor = CheckAnchor(anchor, nameof(anchor));
            Constraints = constraints ?? Array.Empty<JsonSchemaConstraint>();
            Metadata = metadata;
        }

        public virtual Uri? Id { get; }

        public virtual string? Anchor { get; }

        public virtual JsonSchemaMetadata? Metadata { get; }

        public virtual IReadOnlyList<JsonSchemaConstraint> Constraints { get; }

        protected internal abstract void Accept(JsonSchemaVisitor visitor);
    }
}
