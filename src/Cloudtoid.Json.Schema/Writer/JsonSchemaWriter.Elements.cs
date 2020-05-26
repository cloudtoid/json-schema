namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;
    using System.Text.Json;

    public sealed partial class JsonSchemaWriter : JsonSchemaVisitor
    {
        private static readonly JsonEncodedText MetadataId = JsonEncodedText.Encode("$id");
        private static readonly JsonEncodedText MetadataTitle = JsonEncodedText.Encode("title");
        private static readonly JsonEncodedText MetadataDescription = JsonEncodedText.Encode("description");
        private static readonly JsonEncodedText MetadataExamples = JsonEncodedText.Encode("examples");
        private static readonly JsonEncodedText MetadataComment = JsonEncodedText.Encode("$comment");
        private static readonly JsonEncodedText MetadataSchema = JsonEncodedText.Encode("$schema");

        protected internal override void VisitSchema(JsonSchema element)
        {
            var writer = GetSafeWriter();
            writer.WriteStartObject();
            WriteVersion(element.Version);
            base.VisitSchema(element);
            writer.WriteEndObject();
        }

        protected internal override void VisitChildElement(JsonSchemaChildElement element)
        {
            var writer = GetSafeWriter();
            writer.WriteStartObject();
            base.VisitChildElement(element);
            writer.WriteEndObject();
        }

        protected override void VisitMetadata(JsonSchemaMetadata metadata)
        {
            base.VisitMetadata(metadata);

            var writer = this.writer!;

            if (metadata.Id != null)
                writer.WriteString(MetadataId, metadata.Id.ToString());

            if (metadata.Title != null)
                writer.WriteString(MetadataTitle, metadata.Title);

            if (metadata.Description != null)
                writer.WriteString(MetadataDescription, metadata.Description);

            if (metadata.Comment != null)
                writer.WriteString(MetadataComment, metadata.Comment);

            if (metadata.Examples != null)
                WriteExamples(metadata.Examples);
        }

        private void WriteExamples(IReadOnlyCollection<object> examples)
        {
            if (examples.Count == 0)
                return;

            writer!.WriteStartArray(MetadataExamples);
            foreach (var example in examples)
                JsonSerializer.Serialize(writer, example);

            writer.WriteEndArray();
        }

        private void WriteVersion(JsonSchemaVersion version)
        {
            var uri = version.GetSchemaUri();
            writer!.WriteString(MetadataSchema, uri);
        }
    }
}
