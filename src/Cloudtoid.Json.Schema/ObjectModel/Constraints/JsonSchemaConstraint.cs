namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections.Generic;
    using static Contract;

    public abstract class JsonSchemaConstraint
    {
    }

    public class JsonSchemaConstraints : JsonSchemaConstraint
    {
        public static readonly JsonSchemaConstraints Empty = new JsonSchemaConstraints(Array.Empty<JsonSchemaConstraint>());

        public JsonSchemaConstraints(IReadOnlyCollection<JsonSchemaConstraint> constraints)
        {
            Constraints = CheckAllValues(constraints, nameof(constraints));
        }

        public virtual IReadOnlyCollection<JsonSchemaConstraint> Constraints { get; }
    }
}
