namespace Cloudtoid.Json.Schema
{
    using static Contract;

    // the following restrictions can only be applied to Json values of type integer
    public class JsonSchemaInteger : JsonSchemaConstraint
    {
        public JsonSchemaInteger(
            ulong? multipleOf,
            JsonSchemaIntegerRange? range)
        {
            MultipleOf = multipleOf is null ? default : CheckGreaterThan(multipleOf.Value, 0ul, nameof(multipleOf));
            Range = range;
        }

        /// <summary>
        /// Gets a multiple of a given integer to restrict the valid values.
        /// This uses the <c>multipleOf</c> keyword and may only be a positive integer.
        /// </summary>
        public virtual ulong? MultipleOf { get; }

        /// <summary>
        /// Gets the valid range for this integer using a combination of the <c>minimum</c>,
        /// <c>exclusiveMinimum</c>, <c>maximum</c>, and <c>exclusiveMaximum</c> keywords.
        /// </summary>
        public virtual JsonSchemaIntegerRange? Range { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitInteger(this);
    }

    public sealed class JsonSchemaIntegerRange
    {
        public JsonSchemaIntegerRange(JsonSchemaIntegerRangeValue? minimum, JsonSchemaIntegerRangeValue? maximum)
        {
            Check(minimum.HasValue || maximum.HasValue, "Not both minimum and maximum values can be null!");
            Minimum = minimum;
            Maximum = maximum;
        }

        public JsonSchemaIntegerRangeValue? Minimum { get; }

        public JsonSchemaIntegerRangeValue? Maximum { get; }
    }

#pragma warning disable SA1201
    public readonly struct JsonSchemaIntegerRangeValue
#pragma warning restore SA1201
    {
        public JsonSchemaIntegerRangeValue(long value, bool exclusive = false)
        {
            Value = value;
            Exclusive = exclusive;
        }

        public long Value { get; }

        public bool Exclusive { get; }
    }
}
