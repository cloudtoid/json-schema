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
            object? @default = null,
            IReadOnlyCollection<object>? examples = null)
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

        public object? Default { get; }

        public IReadOnlyCollection<object>? Examples { get; }
    }
}
