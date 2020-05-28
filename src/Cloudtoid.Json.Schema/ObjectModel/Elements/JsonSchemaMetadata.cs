namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public sealed class JsonSchemaMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaMetadata"/> class.
        /// </summary>
        /// <param name="title">The title of this schema element.</param>
        /// <param name="description">The description of this schema element.</param>
        /// <param name="comment">The comment from schema authors to readers or maintainers of the schema.</param>
        /// <param name="deprecated">Indicates if the JSON schema element is deprecated.</param>
        /// <param name="readOnly">Indicates if the JSON schema element is read-only.</param>
        /// <param name="writeOnly">Indicates if the JSON schema element is write-only.</param>
        /// <param name="default">The default value for this element if one is not specified.</param>
        /// <param name="examples">An array of examples.</param>
        public JsonSchemaMetadata(
            string? title = null,
            string? description = null,
            string? comment = null,
            bool? deprecated = null,
            bool? readOnly = null,
            bool? writeOnly = null,
            JsonSchemaConstant? @default = null,
            IReadOnlyList<JsonSchemaConstant>? examples = null)
        {
            Title = title;
            Description = description;
            Comment = comment;
            Deprecated = deprecated;
            ReadOnly = readOnly;
            WriteOnly = writeOnly;
            Default = @default;
            Examples = examples;
        }

        public JsonSchemaMetadata()
            : this(null, null, null, null, null, null, null, null)
        {
        }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Comment { get; set; }

        public bool? Deprecated { get; set; }

        public bool? ReadOnly { get; set; }

        public bool? WriteOnly { get; set; }

        public JsonSchemaConstant? Default { get; set; }

        public IReadOnlyList<JsonSchemaConstant>? Examples { get; set; }
    }
}
