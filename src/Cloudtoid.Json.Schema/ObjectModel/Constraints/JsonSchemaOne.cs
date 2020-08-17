using System.Collections.Generic;

namespace Cloudtoid.Json.Schema
{
    public class JsonSchemaOne : JsonSchemaNamedConstraints
    {
        public JsonSchemaOne(IEnumerable<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }

        public JsonSchemaOne()
            : base()
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitOne(this);
    }
}
