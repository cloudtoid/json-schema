namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public class JsonSchemaAny : JsonSchemaNamedConstraints
    {
        public JsonSchemaAny(IEnumerable<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }

        public JsonSchemaAny()
            : base()
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitAny(this);
    }
}
