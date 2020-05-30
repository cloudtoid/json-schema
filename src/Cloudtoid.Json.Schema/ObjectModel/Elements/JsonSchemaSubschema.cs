namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This represents all JSON Schema elements except for the root element which is <see cref="JsonSchema"/>.
    /// </summary>
    public class JsonSchemaSubSchema : JsonSchemaElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaSubSchema"/> class.
        /// </summary>
        /// <param name="id">It identifies a schema resource with its canonical URI.</param>
        /// <param name="anchor">When writing schema documents with the intention to provide re-usable schemas,
        ///     it may be preferable to use a plain name fragment that is not tied to any particular structural location.
        ///     This allows a subschema to be relocated without requiring JSON Pointer references to be updated.</param>
        /// <param name="metadata">The metadata information of this element.</param>
        /// <param name="constraints">The set of constraints applied to this element.</param>
        /// <param name="definitions">The validations that can be reused later using JsonSchemaReference.</param>
        public JsonSchemaSubSchema(
            Uri? id = null,
            string? anchor = null,
            JsonSchemaMetadata? metadata = null,
            IList<JsonSchemaConstraint>? constraints = null,
            IDictionary<string, JsonSchemaSubSchema>? definitions = null)
            : base(id, anchor, metadata, constraints, definitions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaSubSchema"/> class.
        /// </summary>
        /// <param name="id">It identifies a schema resource with its canonical URI.</param>
        /// <param name="anchor">When writing schema documents with the intention to provide re-usable schemas,
        ///     it may be preferable to use a plain name fragment that is not tied to any particular structural location.
        ///     This allows a subschema to be relocated without requiring JSON Pointer references to be updated.</param>
        /// <param name="metadata">The metadata information of this element.</param>
        /// <param name="constraints">The set of constraints applied to this element.</param>
        public JsonSchemaSubSchema(
            Uri? id = null,
            string? anchor = null,
            JsonSchemaMetadata? metadata = null,
            params JsonSchemaConstraint[] constraints)
            : this(id, anchor, metadata, constraints, null)
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitChildElement(this);
    }
}
