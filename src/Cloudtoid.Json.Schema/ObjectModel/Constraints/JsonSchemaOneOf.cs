namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public class JsonSchemaOneOf : JsonSchemaConstraints
    {
        public JsonSchemaOneOf(IReadOnlyCollection<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }
    }
}
