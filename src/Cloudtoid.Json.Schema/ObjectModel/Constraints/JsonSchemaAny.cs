using System.Collections.Generic;

namespace Cloudtoid.Json.Schema
{
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
