namespace Cloudtoid.Json.Schema
{
    using System.Collections;
    using System.Collections.Generic;
    using static Contract;

    /// <summary>
    /// Provides enum style validation.
    /// A JSON validates successfully if it is equal to one of the enum values .
    /// </summary>
    public class JsonSchemaEnum : JsonSchemaConstraint, IReadOnlyList<JsonSchemaConstant>
    {
        private readonly IReadOnlyList<JsonSchemaConstant> values;

        public JsonSchemaEnum(IEnumerable<JsonSchemaConstant> values)
        {
            this.values = CheckValue(values, nameof(values)).AsReadOnlyList();
        }

        public JsonSchemaEnum(params JsonSchemaConstant[] values)
            : this((IReadOnlyList<JsonSchemaConstant>)values)
        {
        }

        public virtual int Count
            => values.Count;

        public virtual JsonSchemaConstant this[int index]
            => values[index];

        public virtual IEnumerator<JsonSchemaConstant> GetEnumerator()
            => values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => values.GetEnumerator();

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitEnum(this);
    }
}
