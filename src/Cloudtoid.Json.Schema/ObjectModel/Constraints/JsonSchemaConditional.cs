namespace Cloudtoid.Json.Schema
{
    using static Contract;

    public class JsonSchemaConditional : JsonSchemaConstraint
    {
        public JsonSchemaConditional(
            JsonSchemaConstraint @if,
            JsonSchemaConstraint? then,
            JsonSchemaConstraint? @else)
        {
            If = CheckValue(@if, nameof(@if));

            Check(then != null || @else != null, "Either 'then' or 'else' clause should be set.");
            Then = then;
            Else = @else;
        }

        public JsonSchemaConstraint If { get; }

        public JsonSchemaConstraint? Then { get; }

        public JsonSchemaConstraint? Else { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitConditional(this);
    }
}
