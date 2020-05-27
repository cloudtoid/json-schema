namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public sealed partial class JsonSchemaWriter
    {
        protected internal override void VisitSchema(JsonSchema element)
        {
            writer.WriteStartObject();
            WriteSchemaVersion(element.Version);
            base.VisitSchema(element);
            writer.WriteEndObject();
        }

        protected override void VisitElement(JsonSchemaElement element)
        {
            base.VisitElement(element);

            if (element.Id != null)
                writer.WriteString(Keys.Id, element.Id.ToString());

            if (element.Anchor != null)
                writer.WriteString(Keys.Anchor, element.Anchor);
        }

        protected internal override void VisitChildElement(JsonSchemaChildElement element)
        {
            writer.WriteStartObject();
            base.VisitChildElement(element);
            writer.WriteEndObject();
        }

        protected override void VisitMetadata(JsonSchemaMetadata metadata)
        {
            base.VisitMetadata(metadata);

            if (metadata.Title != null)
                writer.WriteString(Keys.Title, metadata.Title);

            if (metadata.Description != null)
                writer.WriteString(Keys.Description, metadata.Description);

            if (metadata.Default != null)
                WriteMetadataDefault(metadata.Default);

            if (metadata.Deprecated != null)
                writer.WriteBoolean(Keys.Deprecated, metadata.Deprecated.Value);

            if (metadata.ReadOnly != null)
                writer.WriteBoolean(Keys.ReadOnly, metadata.ReadOnly.Value);

            if (metadata.WriteOnly != null)
                writer.WriteBoolean(Keys.WriteOnly, metadata.WriteOnly.Value);

            if (metadata.Examples != null)
                WriteMetadataExamples(metadata.Examples);

            if (metadata.Comment != null)
                writer.WriteString(Keys.Comment, metadata.Comment);
        }

        private void WriteMetadataDefault(JsonSchemaConstant @default)
        {
            writer.WritePropertyName(Keys.Default);
            WriteConstant(@default);
        }

        private void WriteMetadataExamples(IReadOnlyList<JsonSchemaConstant> examples)
        {
            if (examples.Count == 0)
                return;

            writer.WriteStartArray(Keys.Examples);

            foreach (var example in examples)
                WriteConstant(example);

            writer.WriteEndArray();
        }

        private void WriteSchemaVersion(JsonSchemaVersion version)
        {
            var uri = version.GetSchemaUri();
            writer.WriteString(Keys.Schema, uri);
        }
    }
}
