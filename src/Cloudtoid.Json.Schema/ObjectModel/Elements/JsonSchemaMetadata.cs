namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections.Generic;

    public sealed class JsonSchemaMetadata
    {
        public JsonSchemaMetadata(
            Uri? id,
            string? title = null,
            string? description = null,
            string? comment = null,
            JsonSchemaConstant? @default = null,
            IReadOnlyCollection<JsonSchemaConstant>? examples = null)
        {
            Id = id;
            Title = title;
            Description = description;
            Comment = comment;
            Default = @default;
            Examples = examples;
        }

        public Uri? Id { get; }

        public string? Title { get; }

        public string? Description { get; }

        public string? Comment { get; }

        public JsonSchemaConstant? Default { get; }

        public IReadOnlyCollection<JsonSchemaConstant>? Examples { get; }
    }
}
