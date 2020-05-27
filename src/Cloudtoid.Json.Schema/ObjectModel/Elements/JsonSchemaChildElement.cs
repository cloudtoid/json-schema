namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This represents all Json Schema elements except for the root element which is <see cref="JsonSchema"/>.
    /// </summary>
    public class JsonSchemaChildElement : JsonSchemaElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaChildElement"/> class.
        /// </summary>
        /// <param name="id">It identifies a schema resource with its canonical URI.</param>
        /// <param name="anchor">When writing schema documents with the intention to provide re-usable schemas,
        ///     it may be preferable to use a plain name fragment that is not tied to any particular structural location.
        ///     This allows a subschema to be relocated without requiring JSON Pointer references to be updated.</param>
        /// <param name="metadata">The metadata information of this element.</param>
        /// <param name="constraints">The set of constraints applied to this element.</param>
        public JsonSchemaChildElement(
            Uri? id = null,
            string? anchor = null,
            JsonSchemaMetadata? metadata = null,
            IReadOnlyList<JsonSchemaConstraint>? constraints = null)
            : base(id, anchor, metadata, constraints)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaChildElement"/> class.
        /// </summary>
        /// <param name="id">It identifies a schema resource with its canonical URI.</param>
        /// <param name="anchor">When writing schema documents with the intention to provide re-usable schemas,
        ///     it may be preferable to use a plain name fragment that is not tied to any particular structural location.
        ///     This allows a subschema to be relocated without requiring JSON Pointer references to be updated.</param>
        /// <param name="metadata">The metadata information of this element.</param>
        /// <param name="constraints">The set of constraints applied to this element.</param>
        public JsonSchemaChildElement(
            Uri? id = null,
            string? anchor = null,
            JsonSchemaMetadata? metadata = null,
            params JsonSchemaConstraint[] constraints)
            : this(id, anchor, metadata, (IReadOnlyList<JsonSchemaConstraint>)constraints)
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitChildElement(this);
    }
}
