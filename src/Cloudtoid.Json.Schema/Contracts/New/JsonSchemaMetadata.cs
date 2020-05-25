namespace Cloudtoid.Json.SchemaNew
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using static Contract;

    public enum JsonSchemaType : byte
    {
        Null = 1,
        Object = 2,
        Array = 3,
        String = 4,
        Number = 5,
        Boolean = 6
    }

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

    public abstract class JsonSchemaElementBase
    {
        public JsonSchemaElementBase(
            JsonSchemaConstraints constraints,
            JsonSchemaMetadata? metadata)
        {
            Constraints = CheckValue(constraints, nameof(constraints));
            Metadata = metadata;
        }

        public JsonSchemaConstraints Constraints { get; }

        public JsonSchemaMetadata? Metadata { get; }
    }

    public class JsonSchema : JsonSchemaElementBase
    {
        public JsonSchema(
            JsonSchemaVersion version,
            JsonSchemaConstraints constraints,
            JsonSchemaMetadata? metadata)
            : base(constraints, metadata)
        {
            Version = version;
        }

        public JsonSchemaVersion Version { get; }
    }

    public class JsonSchemaElement : JsonSchemaElementBase
    {
        public JsonSchemaElement(
            JsonSchemaConstraints constraints,
            JsonSchemaMetadata? metadata)
            : base(constraints, metadata)
        {
        }
    }
}
