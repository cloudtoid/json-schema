namespace Cloudtoid.Json.Schema
{
    using System.Text.Json;

    public sealed partial class JsonSchemaWriter
    {
        private static readonly JsonEncodedText[] TypeNames;

        static JsonSchemaWriter()
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

        protected internal override void VisitTypes(JsonSchemaTypes constraint)
        {
            base.VisitTypes(constraint);
            var types = constraint.Types;
            var len = types.Count;
            if (len == 1)
            {
                writer.WriteString(Keys.Type, TypeNames[(int)types[0]]);
                return;
            }

            writer.WriteStartArray(Keys.Type);
            for (int i = 0; i < len; i++)
                writer.WriteStringValue(TypeNames[(int)types[i]]);

            writer.WriteEndArray();
        }
    }
}
