﻿namespace Cloudtoid.Json.Schema
{
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

        /// <summary>
        /// Gets or sets the format string which enforces basic semantic validation on certain kinds of string values that are commonly used.
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
        public string? Format { get; set; }
    }
}