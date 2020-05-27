namespace Cloudtoid.Json.Schema
{
    using System.Collections;
    using System.Collections.Generic;
    using static Contract;

    public class JsonSchemaEnum : JsonSchemaConstraint, IReadOnlyList<JsonSchemaConstant>
    {
        private readonly IReadOnlyList<JsonSchemaConstant> values;

        public JsonSchemaEnum(IReadOnlyList<JsonSchemaConstant> values)
        {
            this.values = CheckValue(values, nameof(values));
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
