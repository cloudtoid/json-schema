using System;
using System.Collections.Generic;

namespace Cloudtoid.Json.Schema
{
    public class JsonSchemaOverride : JsonSchemaSubSchema
    {
        private JsonSchemaSubSchema? schema;
        private JsonSchemaConstraints? constraints;

        public JsonSchemaOverride(
            JsonSchemaSubSchema originalSchema,
            IEnumerable<JsonSchemaConstraint>? constraints = null,
            string? title = null,
            string? description = null,
            string? comment = null,
            bool? deprecated = null,
            bool? readOnly = null,
            bool? writeOnly = null,
            JsonSchemaConstant? @default = null,
            IEnumerable<JsonSchemaConstant>? examples = null,
            IDictionary<string, JsonSchemaSubSchema>? definitions = null)
            : base(
                  constraints: constraints,
                  title: title,
                  description: description,
                  comment: comment,
                  deprecated: deprecated,
                  readOnly: readOnly,
                  writeOnly: writeOnly,
                  @default: @default,
                  examples: examples,
                  definitions: definitions)
        {
            SetOriginalSchema(originalSchema);
        }

        public JsonSchemaOverride()
        {
        }

        /// <inheritdoc/>
        public override JsonSchemaConstraints Constraints
        {
            get => constraints ?? base.Constraints;
            set => throw new InvalidOperationException($"{nameof(Constraints)} is a read-only property");
        }

        /// <inheritdoc/>
        public override bool? Deprecated
        {
            get => base.Deprecated ?? schema?.Deprecated;
            set => base.Deprecated = value;
        }

        /// <inheritdoc/>
        public override bool? ReadOnly
        {
            get => base.ReadOnly ?? schema?.ReadOnly;
            set => base.ReadOnly = value;
        }

        /// <inheritdoc/>
        public override bool? WriteOnly
        {
            get => base.WriteOnly ?? schema?.WriteOnly;
            set => base.WriteOnly = value;
        }

        /// <inheritdoc/>
        public override JsonSchemaConstant? Default
        {
            get => base.Default ?? schema?.Default;
            set => base.Default = value;
        }

        public virtual void SetOriginalSchema(JsonSchemaSubSchema? originalSchema)
        {
            schema = originalSchema;
            constraints = originalSchema is null ? null : new JsonSchemaConstraints(originalSchema.Constraints, base.Constraints);
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitOverride(this);
    }
}
