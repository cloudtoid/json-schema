using System.Collections.Generic;

namespace Cloudtoid.Json.Schema
{
    public class JsonSchemaAll : JsonSchemaNamedConstraints
    {
        public JsonSchemaAll(IEnumerable<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }

        public JsonSchemaAll()
            : base()
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitAll(this);
    }
}
