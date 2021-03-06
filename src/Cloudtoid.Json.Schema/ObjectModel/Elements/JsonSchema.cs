﻿using System;
using System.Collections.Generic;

namespace Cloudtoid.Json.Schema
{
    /// <summary>
    /// This is the root schema resource in a JSON Schema. It is identical to <see cref="JsonSchemaSubSchema"/>,
    /// but has one extra property: <see cref="Version"/>.
    /// </summary>
    public class JsonSchema : JsonSchemaResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchema"/> class.
        /// </summary>
        /// <inheritdoc cref="JsonSchemaResource(Uri?, string?, IEnumerable{JsonSchemaConstraint}?, string?, string?, string?, bool?, bool?, bool?, bool?, JsonSchemaConstant?, IEnumerable{JsonSchemaConstant}?, IDictionary{string, JsonSchemaSubSchema}?)"/>
        public JsonSchema(
            Uri? id = null,
            string? anchor = null,
            IEnumerable<JsonSchemaConstraint>? constraints = null,
            string? title = null,
            string? description = null,
            string? comment = null,
            bool? deprecated = null,
            bool? readOnly = null,
            bool? writeOnly = null,
            bool? recursiveAnchor = null,
            JsonSchemaConstant? @default = null,
            IEnumerable<JsonSchemaConstant>? examples = null,
            IDictionary<string, JsonSchemaSubSchema>? definitions = null)
            : base(id, anchor, constraints, title, description, comment, deprecated, readOnly, writeOnly, recursiveAnchor, @default, examples, definitions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchema"/> class.
        /// </summary>
        public JsonSchema()
            : base()
        {
        }

        /// <summary>
        /// Gets the version of the JSON Schema spec that this document follows.
        /// </summary>
        public virtual JsonSchemaVersion Version { get; } = JsonSchemaVersion.Draft201909;

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitSchema(this);
    }
}
