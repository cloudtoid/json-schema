namespace Cloudtoid.Json.Schema
{
    using static Contract;

    public class JsonSchemaNot : JsonSchemaConstraint
    {
        public JsonSchemaNot(JsonSchemaConstraint not)
        {
            Not = CheckValue(not, nameof(not));
        }

        public virtual JsonSchemaConstraint Not { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitNot(this);
    }
}
