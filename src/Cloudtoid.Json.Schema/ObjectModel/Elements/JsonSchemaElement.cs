namespace Cloudtoid.Json.Schema
{
    using static Contract;

    public abstract class JsonSchemaElement
    {
        public JsonSchemaElement(
            JsonSchemaConstraints constraints,
            JsonSchemaMetadata? metadata)
        {
            Constraints = CheckValue(constraints, nameof(constraints));
            Metadata = metadata;
        }

        public virtual JsonSchemaConstraints Constraints { get; }

        public virtual JsonSchemaMetadata? Metadata { get; }

        protected internal abstract void Accept(JsonSchemaVisitor visitor);
    }
}
