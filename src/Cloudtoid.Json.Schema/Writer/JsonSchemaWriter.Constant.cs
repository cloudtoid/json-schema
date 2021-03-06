﻿using System.Text.Json;

namespace Cloudtoid.Json.Schema
{
    public sealed partial class JsonSchemaWriter
    {
        protected internal override void VisitConstant(JsonSchemaConstant constraint)
        {
            writer.WriteStartObject(Keys.Const);
            base.VisitConstant(constraint);
            writer.WriteEndObject();
        }

        private void WriteConstant(JsonSchemaConstant constant)
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

            JsonSerializer.Serialize(writer, constant.GetValue(), options);
        }
    }
}
