namespace Cloudtoid.Json.Schema
{
    public class JsonSchemaTypeConstraint : JsonSchemaConstraint
    {
        public JsonSchemaTypeConstraint(JsonSchemaType type)
        {
            Type = type;
        }

        public JsonSchemaType Type { get; }
    }
}
