namespace Cloudtoid.Json.Schema
{
    using System.Collections;
    using System.Collections.Generic;
    using static Contract;

    public abstract class JsonSchemaNamedConstraints : JsonSchemaConstraint, IList<JsonSchemaConstraint>
    {
        private LazyValueList<JsonSchemaConstraint> constraints;

        protected JsonSchemaNamedConstraints(IEnumerable<JsonSchemaConstraint> constraints)
        {
            CheckValue(constraints, nameof(constraints));
            this.constraints = new LazyValueList<JsonSchemaConstraint>(constraints);
        }

        protected JsonSchemaNamedConstraints(JsonSchemaConstraint constraint)
        {
            CheckValue(constraint, nameof(constraint));
            constraints = new LazyValueList<JsonSchemaConstraint>(constraint);
        }

        protected JsonSchemaNamedConstraints()
        {
        }

        public virtual int Count
            => constraints.Count;

        public bool IsReadOnly
            => false;

        public virtual JsonSchemaConstraint this[int index]
        {
            get => constraints[index];
            set => constraints[index] = CheckValue(value, nameof(value));
        }

        public void Insert(int index, JsonSchemaConstraint item)
            => constraints.Insert(index, CheckValue(item, nameof(item)));

        public void Add(JsonSchemaConstraint item)
            => constraints.Add(CheckValue(item, nameof(item)));

        public void RemoveAt(int index)
            => constraints.RemoveAt(index);

        public bool Remove(JsonSchemaConstraint item)
            => constraints.Remove(item);

        public int IndexOf(JsonSchemaConstraint item)
            => constraints.IndexOf(item);

        public void Clear()
            => constraints.Clear();

        public bool Contains(JsonSchemaConstraint item)
            => constraints.Contains(item);

        public void CopyTo(JsonSchemaConstraint[] array, int arrayIndex)
            => constraints.CopyTo(array, arrayIndex);

        public virtual IEnumerator<JsonSchemaConstraint> GetEnumerator()
            => constraints.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => constraints.GetEnumerator();
    }
}
