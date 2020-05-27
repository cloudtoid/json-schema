namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using static KeywordsContract;

    public abstract class JsonSchemaElement
    {
        private static readonly IReadOnlyList<JsonSchemaConstraint> EmptyConstraints = Array.Empty<JsonSchemaConstraint>();
        private static readonly IReadOnlyDictionary<string, JsonSchemaSubSchema> EmptyDefinitions = ImmutableDictionary<string, JsonSchemaSubSchema>.Empty;

        protected JsonSchemaElement(
            Uri? id,
            string? anchor,
            JsonSchemaMetadata? metadata,
            IReadOnlyList<JsonSchemaConstraint>? constraints,
            IReadOnlyDictionary<string, JsonSchemaSubSchema>? definitions)
        {
            Id = id;
            Anchor = CheckAnchor(anchor, nameof(anchor));
            Constraints = constraints ?? EmptyConstraints;
            Definitions = definitions ?? EmptyDefinitions;
            Metadata = metadata;
        }

        public virtual Uri? Id { get; }

        public virtual string? Anchor { get; }

        public virtual JsonSchemaMetadata? Metadata { get; }

        public virtual IReadOnlyList<JsonSchemaConstraint> Constraints { get; }

        public virtual IReadOnlyDictionary<string, JsonSchemaSubSchema> Definitions { get; }

        protected internal abstract void Accept(JsonSchemaVisitor visitor);
    }
}
