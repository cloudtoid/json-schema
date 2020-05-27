namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public class JsonSchemaOne : JsonSchemaNamedConstraints
    {
        public JsonSchemaOne(IReadOnlyList<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }

        public JsonSchemaOne(params JsonSchemaConstraint[] constraints)
            : base(constraints)
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitOne(this);
    }
}
