namespace Cloudtoid.Json.Schema
{
    using static Contract;

    public class JsonSchemaNot : JsonSchemaConstraint
    {
        private JsonSchemaConstraint not;

        public JsonSchemaNot(JsonSchemaConstraint not)
        {
            this.not = CheckValue(not, nameof(not));
        }

        public virtual JsonSchemaConstraint Not
        {
            get => not;
            set => not = CheckValue(value, nameof(Not));
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitNot(this);
    }
}
