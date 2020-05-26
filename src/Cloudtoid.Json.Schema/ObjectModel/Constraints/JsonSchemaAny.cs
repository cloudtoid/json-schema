namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public class JsonSchemaAny : JsonSchemaNamedConstraints
    {
        public JsonSchemaAny(IReadOnlyList<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitAny(this);
    }
}
