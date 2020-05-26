namespace Cloudtoid.Json.Schema
{
    using static Contract;

    public class JsonSchemaNot : JsonSchemaConstraint
    {
        public JsonSchemaNot(JsonSchemaConstraint not)
        {
            Not = CheckValue(not, nameof(not));
        }

        public JsonSchemaConstraint Not { get; }
    }
}
