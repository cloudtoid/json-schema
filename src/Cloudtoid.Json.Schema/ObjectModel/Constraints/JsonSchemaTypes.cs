namespace Cloudtoid.Json.Schema
{
    using System.Collections;
    using System.Collections.Generic;
    using static Contract;

    /// <summary>
    /// Provides data type validation.
    /// An instance is valid if and only if the instance is of any of the types listed here.
    /// </summary>
    public class JsonSchemaTypes : JsonSchemaConstraint, IList<JsonSchemaDataType>
    {
        private IList<JsonSchemaDataType> types;

        public JsonSchemaTypes(IEnumerable<JsonSchemaDataType> types)
        {
            CheckValue(types, nameof(types));
            this.types = types.AsMutableList();
        }

        public JsonSchemaTypes(JsonSchemaDataType type)
        {
            types = new List<JsonSchemaDataType>(1) { type };
        }

        public JsonSchemaTypes()
        {
            types = new List<JsonSchemaDataType>();
        }

        public virtual IList<JsonSchemaDataType> Types
        {
            get => types;
            set => types = CheckValue(value, nameof(value));
        }

        public virtual int Count
            => types.Count;

        public bool IsReadOnly
            => false;

        public virtual JsonSchemaDataType this[int index]
        {
            get => types[index];
            set => types[index] = value;
        }

        public void Insert(int index, JsonSchemaDataType type)
            => types.Insert(index, type);

        public void Add(JsonSchemaDataType type)
            => types.Add(type);

        public void RemoveAt(int index)
            => types.RemoveAt(index);

        public bool Remove(JsonSchemaDataType type)
            => types.Remove(type);

        public int IndexOf(JsonSchemaDataType type)
            => types.IndexOf(type);

        public void Clear()
            => types.Clear();

        public bool Contains(JsonSchemaDataType type)
            => types.Contains(type);

        public void CopyTo(JsonSchemaDataType[] array, int arrayIndex)
            => types.CopyTo(array, arrayIndex);

        public virtual IEnumerator<JsonSchemaDataType> GetEnumerator()
            => types.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => types.GetEnumerator();

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitTypes(this);
    }
}
