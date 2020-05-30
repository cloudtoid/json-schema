namespace Cloudtoid.Json.Schema
{
    /// <summary>
    /// Provides the validation rules for string instances.
    /// </summary>
    public class JsonSchemaString : JsonSchemaConstraint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaString"/> class.
        /// </summary>
        /// <param name="minLength">The minimum length of a valid string instance.</param>
        /// <param name="maxLength">The maximum length of a valid string instance.</param>
        /// <param name="pattern">The regular expression that the string value should successfully match.</param>
        /// <param name="format">The format string which enforces basic semantic validation on certain kinds of string instances that are commonly used.</param>
        /// <param name="contentEncoding">The encoding that is used to restrict the value of this string instance.</param>
        /// <param name="contentMedia">The MIME type of the contents of the string instance, as described in RFC 2046, and also the schema for the decoded value.</param>
        public JsonSchemaString(
           uint? minLength = null,
           uint? maxLength = null,
           string? pattern = null,
           string? format = null,
           string? contentEncoding = null,
           JsonSchemaContentMedia? contentMedia = null)
        {
            MinLength = minLength;
            MaxLength = maxLength;
            Pattern = pattern;
            Format = format;
            ContentEncoding = contentEncoding;

            if (contentMedia.HasValue && contentMedia.Value.MediaType != null)
                ContentMedia = contentMedia;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaString"/> class.
        /// </summary>
        public JsonSchemaString()
        {
        }

        /// <summary>
        /// Gets or sets the minimum length of the string. It uses the <c>minLength</c> keyword and its value must be a non-negative number.
        /// </summary>
        public virtual uint? MinLength { get; set; }

        /// <summary>
        /// Gets or sets the maximum length of the string. It uses the <c>maxLength</c> keyword and its value must be a non-negative number.
        /// </summary>
        public virtual uint? MaxLength { get; set; }

        /// <summary>
        /// Gets or sets the regular expression pattern that is used to restrict the value of this string.
        /// The complex syntax of regular expression in JavaScript is supported here, but that complete syntax is not widely supported.
        /// Therefore, it is recommended to use the subset of that syntax described
        /// <a href="https://json-schema.org/understanding-json-schema/reference/regular_expressions.html#regular-expressions">here</a>.
        /// </summary>
        public virtual string? Pattern { get; set; }

        /// <summary>
        /// Gets or sets the format string which enforces basic semantic validation on certain kinds of string values that are commonly used.
        /// This allows values to be constrained beyond what the other tools in JSON Schema, including <see cref="Pattern"/> can do.
        /// As of draft-2019-09 version of the JSON Schema Specification, By default, format is no longer an assertion.
        /// This has been done because the inconsistent implementation of format as an assertion has been an endless source
        /// of surprising problems for schema authors. The default behavior will now be predictable, if not ideal.
        /// We recommend doing semantic validation in the application layer.
        /// <list type="bullet">
        /// <item><term>date</term></item>A string is valid against this format if it represents a date in the following format: <c>YYYY-MM-DD</c>.
        /// <item><term>time</term>A string is valid against this format if it represents a time in the following format: <c>hh:mm:ss.sTZD</c>.</item>
        /// <item><term>date-time</term>A string is valid against this format if it represents a date-time in the following format<c></c>.</item>
        /// <item><term>regex</term>A string is valid against this format if it represents a valid regular expression.</item>
        /// <item><term>email</term>A string is valid against this format if it represents a valid e-mail address format.</item>
        /// <item><term>idn-email</term>A string is valid against this format if it represents a valid IDN e-mail address format.</item>
        /// <item><term>hostname</term>A string is valid against this format if it represents a valid hostname.</item><c></c>.
        /// <item><term>idn-hostname</term>A string is valid against this format if it represents a valid IDN hostname.</item>
        /// <item><term>ipv4</term>A string is valid against this format if it represents a valid IPv4 address.</item>
        /// <item><term>ipv6</term>A string is valid against this format if it represents a valid IPv6 address.</item>
        /// <item><term>json-pointer</term>A string is valid against this format if it represents a valid (absolute) JSON pointer.</item>
        /// <item><term>relative-json-pointer</term>A string is valid against this format if it represents a valid relative JSON pointer.</item>
        /// <item><term>uri</term>A string is valid against this format if it represents a valid uri.</item>
        /// <item><term>uri-reference</term>A string is valid against this format if it represents a valid uri or uri reference.</item>
        /// <item><term>uri-template</term>A string is valid against this format if it represents a valid uri template or uri-reference.</item>
        /// <item><term>iri</term>A string is valid against this format if it represents a valid IRI.</item>
        /// <item><term>iri-reference</term>A string is valid against this format if it represents a valid IRI reference.</item>
        /// </list>
        /// </summary>
        public virtual string? Format { get; set; }

        /// <summary>
        /// Gets the encoding that is used to restrict the value of this string.
        /// The acceptable values are <c>7bit</c>, <c>8bit</c>, <c>binary</c>, <c>quoted-printable</c> and <c>base64</c>. If not specified,
        /// the encoding is the same as the containing JSON document.
        /// </summary>
        public virtual string? ContentEncoding { get; set; }

        /// <summary>
        /// Gets or sets the MIME type of the contents of the string instance, as described in RFC 2046, and also the schema for the decoded value.
        /// </summary>
        public virtual JsonSchemaContentMedia? ContentMedia { get; set; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitString(this);
    }
}
