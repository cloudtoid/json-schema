using System.Text.Json;

namespace Cloudtoid.Json.Schema
{
    internal static class JsonSchemaWriterHelpers
    {
        private static readonly JsonEncodedText[] TypeNames;

        static JsonSchemaWriterHelpers()
        {
            TypeNames = new JsonEncodedText[7];
            TypeNames[(int)JsonSchemaDataType.Null] = JsonEncodedText.Encode("null");
            TypeNames[(int)JsonSchemaDataType.Object] = JsonEncodedText.Encode("object");
            TypeNames[(int)JsonSchemaDataType.Array] = JsonEncodedText.Encode("array");
            TypeNames[(int)JsonSchemaDataType.String] = JsonEncodedText.Encode("string");
            TypeNames[(int)JsonSchemaDataType.Number] = JsonEncodedText.Encode("number");
            TypeNames[(int)JsonSchemaDataType.Integer] = JsonEncodedText.Encode("integer");
            TypeNames[(int)JsonSchemaDataType.Boolean] = JsonEncodedText.Encode("boolean");
        }

        internal static JsonEncodedText GetEncodedTypeName(this JsonSchemaDataType type)
            => TypeNames[(int)type];
    }
}
