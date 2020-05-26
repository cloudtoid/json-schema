namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public class JsonSchemaAnyOf : JsonSchemaConstraints
    {
        public JsonSchemaAnyOf(IReadOnlyCollection<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }
    }
}
