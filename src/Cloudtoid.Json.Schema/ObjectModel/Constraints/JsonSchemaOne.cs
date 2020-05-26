namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public class JsonSchemaOne : JsonSchemaConstraints
    {
        public JsonSchemaOne(IReadOnlyCollection<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitOne(this);
    }
}
