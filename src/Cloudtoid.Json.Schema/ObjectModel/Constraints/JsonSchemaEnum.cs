namespace Cloudtoid.Json.Schema
{
    using System.Collections;
    using System.Collections.Generic;
    using static Contract;

    /// <summary>
    /// Provides enum style validation.
    /// An instance validates successfully if its value is equal to one of the elements .
    /// </summary>
    public class JsonSchemaEnum : JsonSchemaConstraint, IReadOnlyList<JsonSchemaConstant>
    {
        private readonly IReadOnlyList<JsonSchemaConstant> values;

        public JsonSchemaEnum(IReadOnlyList<JsonSchemaConstant> values)
        {
            this.values = CheckValue(values, nameof(values));
        }

        public JsonSchemaEnum(params JsonSchemaConstant[] values)
            : this((IReadOnlyList<JsonSchemaConstant>)values)
        {
        }

        public JsonSchemaEnum(JsonSchemaConstant value)
        {
            CheckValue(value, nameof(value));
            values = new ReadOnlyValueList<JsonSchemaConstant>(value);
        }

        public virtual int Count
            => values.Count;

        public virtual JsonSchemaConstant this[int index]
            => values[index];

        public virtual IEnumerator<JsonSchemaConstant> GetEnumerator()
            => values.GetEnumerator();

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitEnum(this);

        IEnumerator IEnumerable.GetEnumerator()
            => values.GetEnumerator();
    }
}
