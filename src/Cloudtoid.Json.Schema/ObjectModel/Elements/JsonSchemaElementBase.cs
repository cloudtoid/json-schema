namespace Cloudtoid.Json.Schema
{
    using static Contract;

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
}
