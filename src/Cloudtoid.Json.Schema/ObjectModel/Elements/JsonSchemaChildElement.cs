namespace Cloudtoid.Json.Schema
{
    /// <summary>
    /// This represents all Json Schema elements except for the root element which is <see cref="JsonSchema"/>.
    /// </summary>
    public class JsonSchemaChildElement : JsonSchemaElement
    {
        public JsonSchemaChildElement(
            JsonSchemaConstraints constraints,
            JsonSchemaMetadata? metadata)
            : base(constraints, metadata)
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitChildElement(this);
    }
}
