namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using static Contract;

    public abstract class JsonSchemaNamedConstraints : JsonSchemaConstraint, IList<JsonSchemaConstraint>
    {
        private IList<JsonSchemaConstraint> constraints;

        protected JsonSchemaNamedConstraints(IEnumerable<JsonSchemaConstraint> constraints)
        {
            CheckValue(constraints, nameof(constraints));
            this.constraints = CheckAllValues(constraints.AsList(), nameof(constraints));
        }

        protected JsonSchemaNamedConstraints(JsonSchemaConstraint constraint)
        {
            CheckValue(constraint, nameof(constraint));
            constraints = new ValueList<JsonSchemaConstraint>(constraint);
        }

        protected JsonSchemaNamedConstraints()
        {
            constraints = Array.Empty<JsonSchemaConstraint>();
        }

        public virtual int Count
            => constraints.Count;

        public bool IsReadOnly
            => constraints.IsReadOnly;

        public virtual JsonSchemaConstraint this[int index]
        {
            get => constraints[index];
            set => EnsureNotReadOnly()[index] = CheckValue(value, nameof(value));
        }

        public void Insert(int index, JsonSchemaConstraint item)
            => EnsureNotReadOnly().Insert(index, CheckValue(item, nameof(item)));

        public void Add(JsonSchemaConstraint item)
            => EnsureNotReadOnly().Add(CheckValue(item, nameof(item)));

        public void RemoveAt(int index)
            => EnsureNotReadOnly().RemoveAt(index);

        public bool Remove(JsonSchemaConstraint item)
            => constraints.Count != 0 && EnsureNotReadOnly().Remove(item);

        public int IndexOf(JsonSchemaConstraint item)
            => constraints.IndexOf(item);

        public void Clear()
        {
            if (constraints.Count > 0)
                constraints.Clear();
        }

        public bool Contains(JsonSchemaConstraint item)
            => constraints.Contains(item);

        public void CopyTo(JsonSchemaConstraint[] array, int arrayIndex)
            => constraints.CopyTo(array, arrayIndex);

        public virtual IEnumerator<JsonSchemaConstraint> GetEnumerator()
            => constraints.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => constraints.GetEnumerator();

        private IList<JsonSchemaConstraint> EnsureNotReadOnly()
        {
            if (constraints is JsonSchemaConstraint[] || constraints.IsReadOnly)
                constraints = constraints.ToList();

            return constraints;
        }
    }
}
