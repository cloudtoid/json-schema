namespace Cloudtoid.Json.Schema
{
    using System.IO;
    using System.Text.Json;
    using Microsoft.IO;

    public static class JsonSchemaSerializer
    {
        private static readonly RecyclableMemoryStreamManager MemoryStreamManager = new RecyclableMemoryStreamManager();

        public static string Serialize(JsonSchemaElement element, JsonSerializerOptions? options = null)
        {
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
    }
}
