namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public class JsonSchemaEnum : JsonSchemaAny
    {
        public JsonSchemaEnum(IReadOnlyList<JsonSchemaConstant> constraints)
            : base(constraints)
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitEnum(this);
    }
}
