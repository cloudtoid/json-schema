﻿namespace Cloudtoid.Json.Schema
{
    using System.Collections;
    using System.Collections.Generic;
    using static Contract;

    public abstract class JsonSchemaNamedConstraints : JsonSchemaConstraint, IReadOnlyList<JsonSchemaConstraint>
    {
        private readonly IReadOnlyList<JsonSchemaConstraint> constraints;

        protected JsonSchemaNamedConstraints(IReadOnlyList<JsonSchemaConstraint> constraints)
        {
            this.constraints = CheckAllValues(constraints, nameof(constraints));
        }

        public virtual int Count
            => constraints.Count;

        public virtual JsonSchemaConstraint this[int index]
            => constraints[index];

        public virtual IEnumerator<JsonSchemaConstraint> GetEnumerator()
            => constraints.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => constraints.GetEnumerator();
    }
}