namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public class JsonSchemaAllOf : JsonSchemaConstraints
    {
        public JsonSchemaAllOf(IReadOnlyCollection<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }
    }
}
