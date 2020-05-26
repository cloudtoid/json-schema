namespace Cloudtoid.Json.Schema
{
    using static Contract;

    // the following restrictions can only be applied to Json values of type number
    public class JsonSchemaNumber : JsonSchemaConstraint
    {
        public JsonSchemaNumber(
            double? multipleOf,
            JsonSchemaNumberRange? range)
        {
            MultipleOf = multipleOf is null ? default : CheckGreaterThan(multipleOf.Value, 0.0, nameof(multipleOf));
            Range = range;
        }

        /// <summary>
        /// Gets a multiple of a given number to restrict the valid values.
        /// This uses the <c>multipleOf</c> keyword and may only be a positive number.
        /// </summary>
        public virtual double? MultipleOf { get; }

        /// <summary>
        /// Gets the valid range for this number using a combination of the <c>minimum</c>,
        /// <c>exclusiveMinimum</c>, <c>maximum</c>, and <c>exclusiveMaximum</c> keywords.
        /// </summary>
        public virtual JsonSchemaNumberRange? Range { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitNumber(this);
    }

    public sealed class JsonSchemaNumberRange
    {
        public JsonSchemaNumberRange(JsonSchemaNumberRangeValue? minimum, JsonSchemaNumberRangeValue? maximum)
        {
            Contract.Check(minimum.HasValue || maximum.HasValue, "Not both minimum and maximum values can be null!");
            Minimum = minimum;
            Maximum = maximum;
        }

        public JsonSchemaNumberRangeValue? Minimum { get; }

        public JsonSchemaNumberRangeValue? Maximum { get; }
    }

#pragma warning disable SA1201
    public readonly struct JsonSchemaNumberRangeValue
#pragma warning restore SA1201
    {
        public JsonSchemaNumberRangeValue(double value, bool exclusive = false)
        {
            Value = value;
            Exclusive = exclusive;
        }

        public double Value { get; }

        public bool Exclusive { get; }
    }
}
