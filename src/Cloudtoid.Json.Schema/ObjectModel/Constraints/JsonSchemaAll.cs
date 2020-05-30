namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

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
