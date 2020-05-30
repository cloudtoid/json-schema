namespace Cloudtoid.Json.Schema
{
    using static Contract;

    public readonly struct JsonSchemaContentMedia
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaContentMedia"/> struct.
        /// </summary>
        /// <param name="mediaType">The encoding that is used to restrict the value of a string instance.</param>
        /// <param name="schema">The Type is the MIME type of the contents of the string instance, as described in RFC 2046;
        ///     and the Schema defines the structure of the string value after decoding.</param>
        public JsonSchemaContentMedia(string mediaType, JsonSchemaSubSchema? schema = null)
        {
            MediaType = CheckNonEmpty(mediaType, nameof(mediaType));
            Schema = schema;
        }

        /// <summary>
        /// Gets the MIME type of the contents of a string, as described in RFC 2046.
        /// There is a list of MIME types officially registered by the IANA, but the set of types supported will be application
        /// and operating system dependent.
        /// </summary>
        public string? MediaType { get; }

        /// <summary>
        /// Gets the content schema of a string instance.
        /// If <see cref="MediaType"/> is not <see langword="null"/>, this property can contain a schema which describes the
        /// structure of the string.
        /// </summary>
        public JsonSchemaSubSchema? Schema { get; }
    }
}
