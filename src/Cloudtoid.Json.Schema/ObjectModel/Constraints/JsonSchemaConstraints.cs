namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using static Contract;

    public abstract class JsonSchemaConstraints : JsonSchemaConstraint, IReadOnlyCollection<JsonSchemaConstraint>
    {
        public static readonly JsonSchemaConstraints Empty = new JsonSchemaAny(Array.Empty<JsonSchemaConstraint>());
        private readonly IReadOnlyCollection<JsonSchemaConstraint> constraints;

        protected JsonSchemaConstraints(IReadOnlyCollection<JsonSchemaConstraint> constraints)
        {
            this.constraints = CheckAllValues(constraints, nameof(constraints));
        }

        public virtual int Count => constraints.Count;

        public virtual IEnumerator<JsonSchemaConstraint> GetEnumerator()
            => constraints.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => constraints.GetEnumerator();
    }
}
