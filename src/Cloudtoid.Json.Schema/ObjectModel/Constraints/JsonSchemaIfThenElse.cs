namespace Cloudtoid.Json.Schema
{
    using static Contract;

    public class JsonSchemaIfThenElse : JsonSchemaConstraint
    {
        public JsonSchemaIfThenElse(
            JsonSchemaConstraint @if,
            JsonSchemaConstraint then,
            JsonSchemaConstraint? @else)
        {
            If = CheckValue(@if, nameof(@if));
            Then = CheckValue(then, nameof(then));
            Else = @else;
        }

        public JsonSchemaConstraint If { get; }

        public JsonSchemaConstraint Then { get; }

        public JsonSchemaConstraint? Else { get; }
    }
}
