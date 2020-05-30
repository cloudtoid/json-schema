namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This is the root element in a JSON Schema. It is identical to <see cref="JsonSchemaSubSchema"/>,
    /// but has one extra property: <see cref="Version"/>.
    /// </summary>
    public class JsonSchema : JsonSchemaElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchema"/> class.
        /// </summary>
        /// <param name="id">It identifies a schema resource with its canonical URI. The root schema of a JSON Schema
        ///     document SHOULD (not MUST) contain an id with an absolute-URI (containing a scheme, but no fragment).</param>
        /// <param name="anchor">When writing schema documents with the intention to provide re-usable schemas,
        ///     it may be preferable to use a plain name fragment that is not tied to any particular structural location.
        ///     This allows a subschema to be relocated without requiring JSON Pointer references to be updated.</param>
        /// <param name="metadata">The metadata information of this element.</param>
        /// <param name="version">The version of the JSON Schema spec that this document follows.</param>
        /// <param name="constraints">The set of constraints applied to this element.</param>
        /// <param name="definitions">The validations that can be reused later using JsonSchemaReference.</param>
        public JsonSchema(
            Uri? id = null,
            string? anchor = null,
            JsonSchemaMetadata? metadata = null,
            JsonSchemaVersion version = JsonSchemaVersion.Draft201909,
            IList<JsonSchemaConstraint>? constraints = null,
            IDictionary<string, JsonSchemaSubSchema>? definitions = null)
            : base(id, anchor, metadata, constraints, definitions)
        {
            Version = version;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchema"/> class.
        /// </summary>
        /// <param name="id">It identifies a schema resource with its canonical URI. The root schema of a JSON Schema
        ///     document SHOULD (not MUST) contain an id with an absolute-URI (containing a scheme, but no fragment).</param>
        /// <param name="anchor">When writing schema documents with the intention to provide re-usable schemas,
        ///     it may be preferable to use a plain name fragment that is not tied to any particular structural location.
        ///     This allows a subschema to be relocated without requiring JSON Pointer references to be updated.</param>
        /// <param name="metadata">The metadata information of this element.</param>
        /// <param name="version">The version of the JSON Schema spec that this document follows.</param>
        /// <param name="constraints">The set of constraints applied to this element.</param>
        public JsonSchema(
            Uri? id = null,
            string? anchor = null,
            JsonSchemaMetadata? metadata = null,
            JsonSchemaVersion version = JsonSchemaVersion.Draft201909,
            params JsonSchemaConstraint[] constraints)
            : this(id, anchor, metadata, version, constraints, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchema"/> class.
        /// </summary>
        public JsonSchema()
            : this(null)
        {
        }

        /// <summary>
        /// Gets the version of the JSON Schema spec that this document follows.
        /// </summary>
        public virtual JsonSchemaVersion Version { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitSchema(this);
    }
}
