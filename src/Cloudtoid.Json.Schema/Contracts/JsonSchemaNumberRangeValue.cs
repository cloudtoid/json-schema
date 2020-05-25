namespace Cloudtoid.Json.Schema
{
    public readonly struct JsonSchemaNumberRangeValue
    {
        public JsonSchemaNumberRangeValue(double value, bool exclusive = false)
        {
            Value = value;
            Exclusive = exclusive;
        }

        public double Value { get; }

        public bool Exclusive { get; }
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
}
