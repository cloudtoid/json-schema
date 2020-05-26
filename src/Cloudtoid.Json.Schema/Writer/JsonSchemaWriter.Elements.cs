namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public sealed partial class JsonSchemaWriter : JsonSchemaVisitor
    {
        protected internal override void VisitSchema(JsonSchema element)
        {
            CheckNotDisposed();
            writer.WriteStartObject();
            WriteVersion(element.Version);
            base.VisitSchema(element);
            writer.WriteEndObject();
        }

        protected internal override void VisitChildElement(JsonSchemaChildElement element)
        {
            CheckNotDisposed();
            writer.WriteStartObject();
            base.VisitChildElement(element);
            writer.WriteEndObject();
        }

        protected override void VisitMetadata(JsonSchemaMetadata metadata)
        {
            base.VisitMetadata(metadata);

            if (metadata.Id != null)
                writer.WriteString(Keys.Id, metadata.Id.ToString());

            if (metadata.Title != null)
                writer.WriteString(Keys.Title, metadata.Title);

            if (metadata.Description != null)
                writer.WriteString(Keys.Description, metadata.Description);

            if (metadata.Comment != null)
                writer.WriteString(Keys.Comment, metadata.Comment);

            if (metadata.Default != null)
                WriteDefault(metadata.Default);

            if (metadata.Examples != null)
                WriteExamples(metadata.Examples);
        }

        private void WriteDefault(JsonSchemaConstant @default)
        {
            writer.WritePropertyName(Keys.Default);
            WriteConstant(@default);
        }

        private void WriteExamples(IReadOnlyList<JsonSchemaConstant> examples)
        {
            if (examples.Count == 0)
                return;

            writer.WriteStartArray(Keys.Examples);
            foreach (var example in examples)
                WriteConstant(example);

            writer.WriteEndArray();
        }

        private void WriteVersion(JsonSchemaVersion version)
        {
            var uri = version.GetSchemaUri();
            writer.WriteString(Keys.Schema, uri);
        }
    }
}
