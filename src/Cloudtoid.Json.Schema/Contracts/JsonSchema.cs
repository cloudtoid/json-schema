namespace Cloudtoid.Json.Schema
{
    public class JsonSchema
    {
        /// <summary>
        /// Gets or a sets the value that maps to the <c>#schema</c> property on the root element.
        /// </summary>
        public JsonSchemaVersion Version { get; set; }
    }

    /// <summary>
    /// The <c>string</c> type is used for strings of text. It may contain Unicode characters.
    /// </summary>
    public class JsonSchemaString : JsonSchemaType
    {
        public override JsonSchemaTypeKind Kind => JsonSchemaTypeKind.String;

        /// <summary>
        /// Gets or sets the minimum length of the string. It uses the <c>minLength</c> keyword and its value must be a non-negative number.
        /// </summary>
        public uint? MinLength { get; set; }

        /// <summary>
        /// Gets or sets the maximum length of the string. It uses the <c>maxLength</c> keyword and its value must be a non-negative number.
        /// </summary>
        public uint? MaxLength { get; set; }

        /// <summary>
        /// Gets or sets the regular expression pattern that is used to restrict the value of this string.
        /// The complex syntax of regular expression in JavaScript is supported here, but that complete syntax is not widely supported.
        /// Therefore, it is recommended to use the subset of that syntax described <a href="https://json-schema.org/understanding-json-schema/reference/regular_expressions.html#regular-expressions">here</a>.
        /// </summary>
        public string? Pattern { get; set; }
    }
}
