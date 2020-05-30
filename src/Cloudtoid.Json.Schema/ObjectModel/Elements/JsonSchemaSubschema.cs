namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This represents all JSON Schema resources except for the root schema resource which is <see cref="JsonSchema"/>.
    /// </summary>
    public class JsonSchemaSubSchema : JsonSchemaResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaSubSchema"/> class.
        /// </summary>
        /// <inheritdoc cref="JsonSchemaResource(Uri?, string?, IEnumerable{JsonSchemaConstraint}?, string?, string?, string?, bool?, bool?, bool?, JsonSchemaConstant?, IEnumerable{JsonSchemaConstant}?, IDictionary{string, JsonSchemaSubSchema}?)"/>
        public JsonSchemaSubSchema(
            Uri? id = null,
            string? anchor = null,
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
            : base(id, anchor, constraints, title, description, comment, deprecated, readOnly, writeOnly, @default, examples, definitions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaSubSchema"/> class.
        /// </summary>
        public JsonSchemaSubSchema()
            : this(null)
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitSubschema(this);
    }
}
