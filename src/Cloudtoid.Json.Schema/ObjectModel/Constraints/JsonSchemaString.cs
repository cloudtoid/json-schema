namespace Cloudtoid.Json.Schema
{
    // the following restrictions can only be applied to Json values of type string
    public class JsonSchemaString : JsonSchemaConstraint
    {
        public JsonSchemaString(
            uint? minLength = null,
            uint? maxLength = null,
            string? pattern = null,
            string? format = null,
            string? contentEncoding = null,
            string? contentMediaType = null)
        {
            MinLength = minLength;
            MaxLength = maxLength;
            Pattern = pattern;
            Format = format;
            ContentEncoding = contentEncoding;
            ContentMediaType = contentMediaType;
        }

        /// <summary>
        /// Gets the minimum length of the string. It uses the <c>minLength</c> keyword and its value must be a non-negative number.
        /// </summary>
        public virtual uint? MinLength { get; }

        /// <summary>
        /// Gets the maximum length of the string. It uses the <c>maxLength</c> keyword and its value must be a non-negative number.
        /// </summary>
        public virtual uint? MaxLength { get; }

        /// <summary>
        /// Gets the regular expression pattern that is used to restrict the value of this string.
        /// The complex syntax of regular expression in JavaScript is supported here, but that complete syntax is not widely supported.
        /// Therefore, it is recommended to use the subset of that syntax described <a href="https://json-schema.org/understanding-json-schema/reference/regular_expressions.html#regular-expressions">here</a>.
        /// </summary>
        public virtual string? Pattern { get; }

        /// <summary>
        /// Gets the format string which enforces basic semantic validation on certain kinds of string values that are commonly used.
        /// This allows values to be constrained beyond what the other tools in JSON Schema, including <see cref="Pattern"/> can do.
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
        /// <item><term>json-pointer</term>A string is valid against this format if it represents a valid (absolute) json pointer.</item>
        /// <item><term>relative-json-pointer</term>A string is valid against this format if it represents a valid relative json pointer.</item>
        /// <item><term>uri</term>A string is valid against this format if it represents a valid uri.</item>
        /// <item><term>uri-reference</term>A string is valid against this format if it represents a valid uri or uri reference.</item>
        /// <item><term>uri-template</term>A string is valid against this format if it represents a valid uri template or uri-reference.</item>
        /// <item><term>iri</term>A string is valid against this format if it represents a valid IRI.</item>
        /// <item><term>iri-reference</term>A string is valid against this format if it represents a valid IRI reference.</item>
        /// </list>
        /// </summary>
        public virtual string? Format { get; }

        /// <summary>
        /// Gets the encoding that is used to restrict the value of this string.
        /// The acceptable values are <c>7bit</c>, <c>8bit</c>, <c>binary</c>, <c>quoted-printable</c> and <c>base64</c>. If not specified,
        /// the encoding is the same as the containing JSON document.
        /// </summary>
        public virtual string? ContentEncoding { get; }

        /// <summary>
        /// Gets the <c>contentMediaType</c> keyword specifies the MIME type of the contents of a string, as described in RFC 2046.
        /// There is a list of MIME types officially registered by the IANA, but the set of types supported will be application and operating
        /// system dependent.
        /// </summary>
        public virtual string? ContentMediaType { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitString(this);
    }
}
