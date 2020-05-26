namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    public sealed class JsonSchemaMetadata
    {
        public JsonSchemaMetadata(
            Uri? id,
            string? title = null,
            string? description = null,
            string? comment = null,
            JsonElement? @default = null,
            IReadOnlyCollection<JsonElement>? examples = null)
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

        public JsonElement? Default { get; }

        public IReadOnlyCollection<JsonElement>? Examples { get; }
    }
}
