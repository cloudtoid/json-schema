namespace Cloudtoid.Json.Schema
{
    using System.Text.Json;
    using static Contract;

    public class JsonSchemaConstant : JsonSchemaConstraint
    {
        public JsonSchemaConstant(JsonElement element)
        {
            CheckNotEqual(element.ValueKind, JsonValueKind.Undefined, nameof(element.ValueKind));
            Element = element;
        }

        public JsonElement Element { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitConstant(this);
    }
}
