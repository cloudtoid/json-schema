namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public class JsonSchemaEnum : JsonSchemaAnyOf
    {
        public JsonSchemaEnum(IReadOnlyCollection<JsonSchemaConstant> constraints)
            : base(constraints)
        {
        }
    }
}
