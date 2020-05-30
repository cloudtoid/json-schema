namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections.Generic;
    using static Contract;
    using static KeywordsContract;

    public abstract class JsonSchemaElement
    {
        private string? anchor;
        private IList<JsonSchemaConstraint> constraints;

        protected JsonSchemaElement(
            Uri? id,
            string? anchor,
            JsonSchemaMetadata? metadata,
            IList<JsonSchemaConstraint>? constraints,
            IDictionary<string, JsonSchemaSubSchema>? definitions)
        {
            Id = id;
            this.anchor = CheckAnchor(anchor, nameof(anchor));
            Metadata = metadata;
            this.constraints = constraints ?? new List<JsonSchemaConstraint>();
            Definitions = definitions;
        }

        protected JsonSchemaElement()
        {
            constraints = new List<JsonSchemaConstraint>();
        }

        public virtual Uri? Id { get; set; }

        public virtual string? Anchor
        {
            get => anchor;
            set => anchor = CheckAnchor(value, nameof(Anchor));
        }

        public virtual JsonSchemaMetadata? Metadata { get; set; }

        public virtual IList<JsonSchemaConstraint> Constraints
        {
            get => constraints;
            set => constraints = CheckValue(value, nameof(Constraints));
        }

        public virtual IDictionary<string, JsonSchemaSubSchema>? Definitions { get; set; }

        protected internal abstract void Accept(JsonSchemaVisitor visitor);
    }
}
