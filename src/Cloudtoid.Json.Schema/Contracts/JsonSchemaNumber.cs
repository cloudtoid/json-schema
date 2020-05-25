namespace Cloudtoid.Json.Schema
{
    /// <summary>
    /// The number type is used for any numeric type, either integers or floating point numbers.
    /// </summary>
    public class JsonSchemaNumber : JsonSchemaType
    {
        private double? multipleOf;

        public override JsonSchemaTypeKind Kind => JsonSchemaTypeKind.Number;

        /// <summary>
        /// Gets or sets if the type should be set to <c>integer</c> instead of <c>number</c>.
        /// </summary>
        public bool IsInteger { get; set; }

        /// <summary>
        /// Gets or sets a multiple of a given number to restrict the valid values.
        /// This uses the <c>multipleOf</c> keyword and may only be a positive number.
        /// </summary>
        public double? MultipleOf
        {
            get => multipleOf;
            set => multipleOf = value is null ? default : Contract.CheckGreaterThanl(value.Value, 0.0, nameof(MultipleOf));
        }

        /// <summary>
        /// Gets or sets the valid range for this number using a combination of the <c>minimum</c>,
        /// <c>exclusiveMinimum</c>, <c>maximum</c>, and <c>exclusiveMaximum</c> keywords.
        /// </summary>
        public JsonSchemaNumberRange? Range { get; set; }
    }
}
