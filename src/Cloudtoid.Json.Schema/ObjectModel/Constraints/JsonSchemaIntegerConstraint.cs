namespace Cloudtoid.Json.Schema
{
    using static Contract;

    // the following restrictions can only be applied to json values of type integer
    public class JsonSchemaIntegerConstraint : JsonSchemaConstraint
    {
        public JsonSchemaIntegerConstraint(
            int? multipleOf,
            JsonSchemaIntegerRange? range)
        {
            MultipleOf = multipleOf is null ? default : CheckGreaterThan(multipleOf.Value, 0, nameof(multipleOf));
            Range = range;
        }

        /// <summary>
        /// Gets a multiple of a given number to restrict the valid values.
        /// This uses the <c>multipleOf</c> keyword and may only be a positive number.
        /// </summary>
        public int? MultipleOf { get; }

        /// <summary>
        /// Gets the valid range for this number using a combination of the <c>minimum</c>,
        /// <c>exclusiveMinimum</c>, <c>maximum</c>, and <c>exclusiveMaximum</c> keywords.
        /// </summary>
        public JsonSchemaIntegerRange? Range { get; }
    }

    public sealed class JsonSchemaIntegerRange
    {
        public JsonSchemaIntegerRange(JsonSchemaIntegerRangeValue? minimum, JsonSchemaIntegerRangeValue? maximum)
        {
            Contract.Check(minimum.HasValue || maximum.HasValue, "Not both minimum and maximum values can be null!");
            Minimum = minimum;
            Maximum = maximum;
        }

        public JsonSchemaIntegerRangeValue? Minimum { get; }

        public JsonSchemaIntegerRangeValue? Maximum { get; }
    }

#pragma warning disable SA1201 // Elements should appear in the correct order
    public readonly struct JsonSchemaIntegerRangeValue
#pragma warning restore SA1201 // Elements should appear in the correct order
    {
        public JsonSchemaIntegerRangeValue(int value, bool exclusive = false)
        {
            Value = value;
            Exclusive = exclusive;
        }

        public int Value { get; }

        public bool Exclusive { get; }
    }
}
