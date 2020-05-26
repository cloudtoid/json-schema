namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public class JsonSchemaAll : JsonSchemaConstraints
    {
        public JsonSchemaAll(IReadOnlyCollection<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitAll(this);
    }
}
