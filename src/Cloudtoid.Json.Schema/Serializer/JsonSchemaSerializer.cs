namespace Cloudtoid.Json.Schema
{
    using System.IO;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.IO;
    using static Contract;

    public static class JsonSchemaSerializer
    {
        private static readonly RecyclableMemoryStreamManager MemoryStreamManager = new RecyclableMemoryStreamManager();

        public static string Serialize(
            JsonSchemaElement element,
            JsonSerializerOptions? options = null)
        {
            CheckValue(element, nameof(element));

            using (var stream = MemoryStreamManager.GetStream())
            using (var reader = new StreamReader(stream, System.Text.Encoding.UTF8))
            using (var writer = new JsonSchemaWriter(stream, options))
            {
                writer.Write(element);
                writer.Flush();
                stream.Position = 0;
                return reader.ReadToEnd();
            }
        }

        public static async Task SerializeAsync(
            Utf8JsonWriter writer,
            JsonSchemaElement element,
            JsonSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            CheckValue(writer, nameof(writer));
            CheckValue(element, nameof(element));

            using (var schemaWriter = new JsonSchemaWriter(writer, options))
            {
                schemaWriter.Write(element);
                await schemaWriter.FlushAsync(cancellationToken);
            }
        }

        public static async Task SerializeAsync(
            Stream stream,
            JsonSchemaElement element,
            JsonSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            CheckValue(stream, nameof(stream));
            CheckValue(element, nameof(element));

            using (var schemaWriter = new JsonSchemaWriter(stream, options))
            {
                schemaWriter.Write(element);
                await schemaWriter.FlushAsync(cancellationToken);
            }
        }
    }
}
