namespace Cloudtoid.Json.Schema
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using static Contract;

    /// <summary>
    /// Provides a high-performance API for forward-only, non-cached writing of UTF-8 encoded JSON Schema text.
    /// </summary>
    public sealed partial class JsonSchemaWriter : JsonSchemaVisitor, IDisposable, IAsyncDisposable
    {
        private readonly Utf8JsonWriter writer;
        private readonly JsonSerializerOptions? options;
        private readonly bool ownsWriter;
        private bool disposed;

        public JsonSchemaWriter(Stream stream, JsonSerializerOptions? options = null)
        {
            CheckValue(stream, nameof(stream));
            writer = new Utf8JsonWriter(stream, GetWriterOptions(options));
            this.options = options;
            ownsWriter = true;
        }

        public JsonSchemaWriter(Utf8JsonWriter writer, JsonSerializerOptions? options = null)
        {
            this.writer = CheckValue(writer, nameof(writer));
            this.options = options;
            ownsWriter = false;
        }

        /// <summary>
        /// Writes the <paramref name="element"/> to the provided stream/writer/buffer.
        /// </summary>
        public void Write(JsonSchemaElement element)
        {
            CheckNotDisposed();

            Visit(element);
        }

        public void Dispose()
        {
            if (disposed)
                return;

            disposed = true;
            if (ownsWriter)
                writer.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            if (disposed)
                return;

            disposed = true;
            if (ownsWriter)
                await writer.DisposeAsync();
        }

        /// <summary>
        /// Commits the JSON Schema text written so far which makes it visible to the output destination.
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        ///   The instance of <see cref="JsonSchemaWriter"/> has been disposed.
        /// </exception>
        public void Flush()
        {
            CheckNotDisposed();

            writer.Flush();
        }

        /// <summary>
        /// Asynchronously commits the JSON Schema text written so far which makes it visible to the output destination.
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        ///   The instance of <see cref="JsonSchemaWriter"/> has been disposed.
        /// </exception>
        public async Task FlushAsync(CancellationToken cancellationToken = default)
        {
            CheckNotDisposed();

            await writer.FlushAsync(cancellationToken);
        }

        private void CheckNotDisposed()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(JsonSchemaWriter));
        }

        private static JsonWriterOptions GetWriterOptions(JsonSerializerOptions? options)
        {
            return new JsonWriterOptions
            {
                Indented = options?.WriteIndented ?? false,
                Encoder = options?.Encoder ?? null,
                SkipValidation = true
            };
        }
    }
}
