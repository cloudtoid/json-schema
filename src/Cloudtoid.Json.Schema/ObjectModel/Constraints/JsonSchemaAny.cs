namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public class JsonSchemaAny : JsonSchemaNamedConstraints
    {
        public JsonSchemaAny(IReadOnlyList<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }

        public JsonSchemaAny(params JsonSchemaConstraint[] constraints)
            : base(constraints)
        {
        }

        public JsonSchemaAny(JsonSchemaConstraint constraint)
            : base(constraint)
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitAny(this);
    }
}
