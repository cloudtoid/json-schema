namespace Cloudtoid.Json.Schema
{
    public class JsonSchemaType : JsonSchemaConstraint
    {
        public JsonSchemaType(JsonSchemaDataType type)
        {
            Type = type;
        }

        public virtual JsonSchemaDataType Type { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitType(this);
    }
}
