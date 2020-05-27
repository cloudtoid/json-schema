namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public class JsonSchemaAll : JsonSchemaNamedConstraints
    {
        public JsonSchemaAll(IReadOnlyList<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }

        public JsonSchemaAll(params JsonSchemaConstraint[] constraints)
            : base(constraints)
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitAll(this);
    }
}
