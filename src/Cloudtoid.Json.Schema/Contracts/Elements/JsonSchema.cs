﻿namespace Cloudtoid.Json.SchemaNew
{
    public class JsonSchema : JsonSchemaElementBase
    {
        public JsonSchema(
            JsonSchemaVersion version,
            JsonSchemaConstraints constraints,
            JsonSchemaMetadata? metadata)
            : base(constraints, metadata)
        {
            Version = version;
        }

        public JsonSchemaVersion Version { get; }
    }
}
