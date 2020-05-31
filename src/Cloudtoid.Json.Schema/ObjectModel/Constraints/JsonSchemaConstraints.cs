namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using static Contract;

    internal class JsonSchemaConstraints : IList<JsonSchemaConstraint>
    {
        private readonly bool readOnlyConstraints;
        private IList<JsonSchemaConstraint>? constraints;
        private IList<JsonSchemaConstraint>? overrides;

        internal JsonSchemaConstraints(IEnumerable<JsonSchemaConstraint>? constraints = null)
        {
            if (constraints != null)
                this.constraints = constraints.AsMutableList();
        }

        internal JsonSchemaConstraints(
            IList<JsonSchemaConstraint> constraints,
            IList<JsonSchemaConstraint>? overrides)
        {
            readOnlyConstraints = true;
            this.constraints = constraints;

            if (overrides != null)
                this.overrides = overrides.AsMutableList();
        }

        public int Count
            => (constraints?.Count + overrides?.Count) ?? 0;

        public bool IsReadOnly
            => false;

        public JsonSchemaConstraint this[int index]
        {
            get
            {
                var constraints = this.constraints;
                var overrides = this.overrides;

                if (constraints != null)
                {
                    if (index < constraints.Count)
                        return constraints[index];

                    index -= constraints.Count;
                }

                if (overrides != null)
                    return overrides[index];

                throw new ArgumentOutOfRangeException();
            }

            set
            {
                CheckValue(value, nameof(value));

                var constraints = this.constraints;
                var overrides = this.overrides;

                if (constraints != null)
                {
                    if (index < constraints.Count)
                    {
                        if (readOnlyConstraints)
                            throw new InvalidOperationException($"Index {index} is a read-only element as it was defined in the parent schema resource.");

                        constraints[index] = value;
                        return;
                    }

                    index -= constraints.Count;
                }

                if (overrides != null)
                {
                    overrides[index] = value;
                    return;
                }

                throw new ArgumentOutOfRangeException();
            }
        }

        public void Add(JsonSchemaConstraint item)
            => Ensure().Add(CheckValue(item, nameof(item)));

        public void Insert(int index, JsonSchemaConstraint item)
        {
            CheckValue(item, nameof(item));

            if (!readOnlyConstraints)
            {
                EnsureConstraints().Insert(index, item);
                return;
            }

            if (constraints != null)
                index -= constraints.Count;

            if (index < 0)
                throw new InvalidOperationException($"Index {index} is in the parent schema resource which is read-only.");

            EnsureOverrides().Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            if (readOnlyConstraints)
            {
                if (overrides is null)
                    throw new ArgumentOutOfRangeException();

                if (constraints != null)
                    index -= constraints.Count;

                if (index < 0)
                    throw new InvalidOperationException($"Index {index} is in the parent schema resource which is read-only.");

                overrides.RemoveAt(index);
            }
            else
            {
                if (constraints is null)
                    throw new ArgumentOutOfRangeException();

                constraints.RemoveAt(index);
            }
        }

        public bool Remove(JsonSchemaConstraint item)
        {
            CheckValue(item, nameof(item));

            var list = readOnlyConstraints ? overrides : constraints;
            return list != null && list.Remove(item);
        }

        public void Clear()
        {
            if (readOnlyConstraints)
                throw new NotSupportedException();

            constraints?.Clear();
        }

        public bool Contains(JsonSchemaConstraint item)
            => (constraints?.Contains(item) == true) || (overrides?.Contains(item) == true);

        public int IndexOf(JsonSchemaConstraint item)
        {
            CheckValue(item, nameof(item));

            int index = 0;
            if (constraints != null)
            {
                var i = constraints.IndexOf(item);
                if (i != -1)
                    return i;

                index += constraints.Count;
            }

            if (overrides != null)
            {
                var i = overrides.IndexOf(item);
                if (i != -1)
                    return index + i;
            }

            return -1;
        }

        public void CopyTo(JsonSchemaConstraint[] array, int arrayIndex)
        {
            var constraints = this.constraints;
            if (constraints != null)
            {
                constraints.CopyTo(array, arrayIndex);
                arrayIndex = +constraints.Count;
            }

            var overrides = this.overrides;
            if (overrides != null)
                overrides.CopyTo(array, arrayIndex);
        }

        public Enumerator GetEnumerator()
            => new Enumerator(this);

        IEnumerator<JsonSchemaConstraint> IEnumerable<JsonSchemaConstraint>.GetEnumerator()
            => new Enumerator(this);

        IEnumerator IEnumerable.GetEnumerator()
            => new Enumerator(this);

        private IList<JsonSchemaConstraint> Ensure()
            => readOnlyConstraints ? EnsureOverrides() : EnsureConstraints();

        private IList<JsonSchemaConstraint> EnsureConstraints()
            => constraints ??= new List<JsonSchemaConstraint>();

        private IList<JsonSchemaConstraint> EnsureOverrides()
            => overrides ??= new List<JsonSchemaConstraint>();

        public struct Enumerator : IEnumerator<JsonSchemaConstraint>, IEnumerator
        {
            private readonly JsonSchemaConstraints parent;
            private JsonSchemaConstraint? current;
            private int index;

            internal Enumerator(JsonSchemaConstraints parent)
            {
                this.parent = parent;
                current = null;
                index = 0;
            }

            public JsonSchemaConstraint Current
                => current ?? throw new InvalidOperationException();

            object IEnumerator.Current
                => Current;

            public bool MoveNext()
            {
                var constraints = parent.constraints;
                int index = this.index;
                if (constraints != null)
                {
                    if (index < constraints.Count)
                    {
                        current = constraints[this.index++];
                        return true;
                    }

                    index -= constraints.Count;
                }

                var overrides = parent.overrides;
                if (overrides is null || index >= overrides.Count)
                    return false;

                current = overrides[index];
                this.index++;
                return true;
            }

            public void Reset()
            {
                index = 0;
                current = null;
            }

            public void Dispose()
            {
            }
        }
    }
}
