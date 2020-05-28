namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public class JsonSchemaOne : JsonSchemaNamedConstraints
    {
        public JsonSchemaOne(IEnumerable<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }

        public JsonSchemaOne(params JsonSchemaConstraint[] constraints)
            : base(constraints)
        {
        }

        public JsonSchemaOne(JsonSchemaConstraint constraint)
            : base(constraint)
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
