using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IO;
using static Cloudtoid.Contract;

namespace Cloudtoid.Json.Schema
{
    public static class JsonSchemaSerializer
    {
        private static readonly RecyclableMemoryStreamManager MemoryStreamManager = new RecyclableMemoryStreamManager();

        public static string Serialize(
            JsonSchemaResource resource,
            JsonSerializerOptions? options = null)
        {
            CheckValue(resource, nameof(resource));

            using (var stream = MemoryStreamManager.GetStream())
            using (var reader = new StreamReader(stream, System.Text.Encoding.UTF8))
            using (var writer = new JsonSchemaWriter(stream, options))
            {
                writer.Write(resource);
                writer.Flush();
                stream.Position = 0;
                return reader.ReadToEnd();
            }
        }

        public static async Task SerializeAsync(
            Utf8JsonWriter writer,
            JsonSchemaResource resource,
            JsonSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            CheckValue(writer, nameof(writer));
            CheckValue(resource, nameof(resource));

            using (var schemaWriter = new JsonSchemaWriter(writer, options))
            {
                schemaWriter.Write(resource);
                await schemaWriter.FlushAsync(cancellationToken);
            }
        }

        public static async Task SerializeAsync(
            Stream stream,
            JsonSchemaResource resource,
            JsonSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            CheckValue(stream, nameof(stream));
            CheckValue(resource, nameof(resource));

            using (var schemaWriter = new JsonSchemaWriter(stream, options))
            {
                schemaWriter.Write(resource);
                await schemaWriter.FlushAsync(cancellationToken);
            }
        }
    }
}
