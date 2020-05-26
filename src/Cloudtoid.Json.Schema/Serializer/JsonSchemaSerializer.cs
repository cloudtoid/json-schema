namespace Cloudtoid.Json.Schema
{
    using System.IO;
    using System.Text.Encodings.Web;
    using System.Text.Json;
    using Microsoft.IO;

    public static class JsonSchemaSerializer
    {
        private static readonly RecyclableMemoryStreamManager MemoryStreamManager = new RecyclableMemoryStreamManager();

        public static string Serialize(JsonSchemaElement element, JsonSchemaSerializerOptions? options = null)
        {
            using (var stream = MemoryStreamManager.GetStream())
            using (var reader = new StreamReader(stream, System.Text.Encoding.UTF8))
            using (var writer = new JsonSchemaWriter(stream, options is null ? default : options.GetWriterOptions()))
            {
                writer.Write(element);
                writer.Flush();
                stream.Position = 0;
                return reader.ReadToEnd();
            }
        }
    }

    public sealed class JsonSchemaSerializerOptions
    {
        /// <summary>
        /// The encoder to use when escaping strings, or <see langword="null" /> to use the default encoder.
        /// </summary>
        public JavaScriptEncoder? Encoder { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether the System.Text.Json.Utf8JsonWriter
        ///     should format the JSON output, which includes indenting nested JSON tokens, adding
        ///     new lines, and adding white space between property names and values.
        /// </summary>
        public bool Indented { get; set; }

        internal JsonWriterOptions GetWriterOptions()
        {
            return new JsonWriterOptions
            {
                Encoder = Encoder,
                Indented = Indented,
                SkipValidation = true,
            };
        }
    }
}
