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

        public string? Title { get; }

        public string? Description { get; }

        public string? Comment { get; }

        public bool? Deprecated { get; }

        public bool? ReadOnly { get; }

        public bool? WriteOnly { get; }

        public JsonSchemaConstant? Default { get; }

        public IReadOnlyList<JsonSchemaConstant>? Examples { get; }
    }
}
