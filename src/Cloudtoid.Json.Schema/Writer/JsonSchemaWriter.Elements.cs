namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;
    using System.Text.Json;

    public sealed partial class JsonSchemaWriter : JsonSchemaVisitor
    {
        private static readonly JsonEncodedText MetadataId = JsonEncodedText.Encode("$id");
        private static readonly JsonEncodedText MetadataTitle = JsonEncodedText.Encode("title");
        private static readonly JsonEncodedText MetadataDescription = JsonEncodedText.Encode("description");
        private static readonly JsonEncodedText MetadataDefault = JsonEncodedText.Encode("default");
        private static readonly JsonEncodedText MetadataExamples = JsonEncodedText.Encode("examples");
        private static readonly JsonEncodedText MetadataComment = JsonEncodedText.Encode("$comment");
        private static readonly JsonEncodedText MetadataSchema = JsonEncodedText.Encode("$schema");

        protected internal override void VisitSchema(JsonSchema element)
        {
            CheckNotDisposed();
            writer.WriteStartObject();
            Writen(element.Version);
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
                writer.WriteString(MetadataId, metadata.Id.ToString());

            if (metadata.Title != null)
                writer.WriteString(MetadataTitle, metadata.Title);

            if (metadata.Description != null)
                writer.WriteString(MetadataDescription, metadata.Description);

            if (metadata.Comment != null)
                writer.WriteString(MetadataComment, metadata.Comment);

            if (metadata.Default != null)
                WriteDefault(metadata.Default);

            if (metadata.Examples != null)
                WriteExamples(metadata.Examples);
        }

        private void WriteDefault(JsonSchemaConstant @default)
        {
            writer.WritePropertyName(MetadataDefault);
            Write(@default);
        }

        private void WriteExamples(IReadOnlyCollection<JsonSchemaConstant> examples)
        {
            if (examples.Count == 0)
                return;

            writer.WriteStartArray(MetadataExamples);
            foreach (var example in examples)
                Write(example);

            writer.WriteEndArray();
        }

        private void Writen(JsonSchemaVersion version)
        {
            var uri = version.GetSchemaUri();
            writer.WriteString(MetadataSchema, uri);
        }

        private void Write(JsonSchemaConstant constant)
        {
            if (constant.IsNull)
            {
                writer.WriteNullValue();
                return;
            }

            var type = constant.ValueType;
            if (type.IsValueType)
            {
                switch (constant)
                {
                    case JsonSchemaConstant<int> c:
                        writer.WriteNumberValue(c.Value);
                        return;

                    case JsonSchemaConstant<int?> c:
                        writer.WriteNumberValue(c.Value!.Value);
                        return;

                    case JsonSchemaConstant<bool> c:
                        writer.WriteBooleanValue(c.Value);
                        return;

                    case JsonSchemaConstant<bool?> c:
                        writer.WriteBooleanValue(c.Value!.Value);
                        return;

                    case JsonSchemaConstant<double> c:
                        writer.WriteNumberValue(c.Value);
                        return;

                    case JsonSchemaConstant<double?> c:
                        writer.WriteNumberValue(c.Value!.Value);
                        return;

                    case JsonSchemaConstant<long> c:
                        writer.WriteNumberValue(c.Value);
                        return;

                    case JsonSchemaConstant<long?> c:
                        writer.WriteNumberValue(c.Value!.Value);
                        return;

                    case JsonSchemaConstant<decimal> c:
                        writer.WriteNumberValue(c.Value);
                        return;

                    case JsonSchemaConstant<decimal?> c:
                        writer.WriteNumberValue(c.Value!.Value);
                        return;

                    case JsonSchemaConstant<uint> c:
                        writer.WriteNumberValue(c.Value);
                        return;

                    case JsonSchemaConstant<uint?> c:
                        writer.WriteNumberValue(c.Value!.Value);
                        return;

                    case JsonSchemaConstant<ulong> c:
                        writer.WriteNumberValue(c.Value);
                        return;

                    case JsonSchemaConstant<ulong?> c:
                        writer.WriteNumberValue(c.Value!.Value);
                        return;

                    case JsonSchemaConstant<float> c:
                        writer.WriteNumberValue(c.Value);
                        return;

                    case JsonSchemaConstant<float?> c:
                        writer.WriteNumberValue(c.Value!.Value);
                        return;

                    case JsonSchemaConstant<short> c:
                        writer.WriteNumberValue(c.Value);
                        return;

                    case JsonSchemaConstant<short?> c:
                        writer.WriteNumberValue(c.Value!.Value);
                        return;

                    case JsonSchemaConstant<ushort> c:
                        writer.WriteNumberValue(c.Value);
                        return;

                    case JsonSchemaConstant<ushort?> c:
                        writer.WriteNumberValue(c.Value!.Value);
                        return;

                    default:
                        break;
                }
            }
            else if (constant is JsonSchemaConstant<string> str)
            {
                writer.WriteStringValue(str.Value);
                return;
            }

            JsonSerializer.Serialize(writer, constant.GetValue());
        }
    }
}
