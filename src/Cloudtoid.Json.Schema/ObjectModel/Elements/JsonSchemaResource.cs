namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections.Generic;
    using static Contract;
    using static KeywordsContract;

    public abstract class JsonSchemaResource
    {
        private string? anchor;
        private IList<JsonSchemaConstraint> constraints;

        /// <param name="id">It identifies a schema resource with its canonical URI.</param>
        /// <param name="anchor">When writing schema documents with the intention to provide re-usable schemas,
        ///     it may be preferable to use a plain name fragment that is not tied to any particular structural location.
        ///     This allows a subschema to be relocated without requiring JSON Pointer references to be updated.</param>
        /// <param name="constraints">The list of constraints that apply to this schema resource.</param>
        /// <param name="title">The title of this schema resource.</param>
        /// <param name="description">The description of this schema resource.</param>
        /// <param name="comment">The comment from schema authors to readers or maintainers of the schema.</param>
        /// <param name="deprecated">Indicates if the JSON schema resource is deprecated.</param>
        /// <param name="readOnly">Indicates if the JSON schema resource is read-only.</param>
        /// <param name="writeOnly">Indicates if the JSON schema resource is write-only.</param>
        /// <param name="recursiveAnchor">Indicates if recursive references to this schema resource should be evaluated dynamically.
        ///     See the JSON schema <a href="https://json-schema.org/draft/2019-09/json-schema-core.html#recursive-example">spec</a>
        ///     for more information.</param>
        /// <param name="default">The default value for this schema resource if one is not specified.</param>
        /// <param name="examples">The array of JSON examples.</param>
        /// <param name="definitions">The validations that can be referred to later using a <see cref="RecursiveAnchor"/>.</param>
        protected JsonSchemaResource(
            Uri? id,
            string? anchor,
            IEnumerable<JsonSchemaConstraint>? constraints,
            string? title,
            string? description,
            string? comment,
            bool? deprecated,
            bool? readOnly,
            bool? writeOnly,
            bool? recursiveAnchor,
            JsonSchemaConstant? @default,
            IEnumerable<JsonSchemaConstant>? examples,
            IDictionary<string, JsonSchemaSubSchema>? definitions)
        {
            Id = id;
            Anchor = anchor;
            this.constraints = new JsonSchemaConstraints(constraints);
            Title = title;
            Description = description;
            Comment = comment;
            Deprecated = deprecated;
            ReadOnly = readOnly;
            WriteOnly = writeOnly;
            RecursiveAnchor = recursiveAnchor;
            Default = @default;
            Examples = examples?.AsMutableList();
            Definitions = definitions;
        }

        protected JsonSchemaResource()
        {
            constraints = new JsonSchemaConstraints();
        }

        /// <summary>
        /// Gets or sets the schema resource identifier which should be a canonical URI.
        /// </summary>
        public virtual Uri? Id { get; set; }

        /// <summary>
        /// Gets or sets the anchor for this schema resource.
        /// </summary>
        /// <remarks>
        /// When writing schema documents with the intention to provide re-usable schemas,it may be preferable
        /// to use a plain name fragment that is not tied to any particular structural location.
        /// This allows a subschema to be relocated without requiring JSON Pointer references to be updated.
        /// </remarks>
        public virtual string? Anchor
        {
            get => anchor;
            set => anchor = CheckAnchor(value, nameof(Anchor));
        }

        /// <summary>
        /// Gets or sets is a recursive reference to this schema resource should be evaluated dynamically.
        /// See the official JSON schema <a href="https://json-schema.org/draft/2019-09/json-schema-core.html#recursive-example">spec</a>
        /// for more information.
        /// </summary>
        public virtual bool? RecursiveAnchor { get; set; }

        /// <summary>
        /// Gets or sets the constraints that apply to this schema resource.
        /// </summary>
        public virtual IList<JsonSchemaConstraint> Constraints
        {
            get => constraints;
            set => constraints = CheckValue(value, nameof(Constraints));
        }

        /// <summary>
        /// Gets or sets the title of this schema resource.
        /// </summary>
        public virtual string? Title { get; set; }

        /// <summary>
        /// Gets or sets the description of this schema resource.
        /// </summary>
        public virtual string? Description { get; set; }

        /// <summary>
        /// Gets or sets the comment from schema authors to readers or maintainers of the schema.
        /// </summary>
        public virtual string? Comment { get; set; }

        /// <summary>
        /// Gets or sets if the JSON schema resource is deprecated.
        /// </summary>
        public virtual bool? Deprecated { get; set; }

        /// <summary>
        /// Gets or sets if the JSON schema resource is read-only.
        /// </summary>
        public virtual bool? ReadOnly { get; set; }

        /// <summary>
        /// Gets or sets if the JSON schema resource is write-only.
        /// </summary>
        public virtual bool? WriteOnly { get; set; }

        /// <summary>
        /// Gets or sets the default value for this schema resource if one is not specified.
        /// </summary>
        public virtual JsonSchemaConstant? Default { get; set; }

        /// <summary>
        /// Gets or sets the array of examples.
        /// </summary>
        public virtual IList<JsonSchemaConstant>? Examples { get; set; }

        /// <summary>
        /// Gets or sets the validations that can be referred to later using <see cref="RecursiveAnchor"/>.
        /// </summary>
        public virtual IDictionary<string, JsonSchemaSubSchema>? Definitions { get; set; }

        protected internal abstract void Accept(JsonSchemaVisitor visitor);
    }
}
