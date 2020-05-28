namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public class JsonSchemaAny : JsonSchemaNamedConstraints
    {
        public JsonSchemaAny(IEnumerable<JsonSchemaConstraint> constraints)
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

        public JsonSchemaAny()
            : base()
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitAny(this);
    }
}
