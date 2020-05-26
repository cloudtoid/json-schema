namespace Cloudtoid.Json.Schema
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides a high-performance API for forward-only, non-cached writing of UTF-8 encoded Json Schema text.
    /// </summary>
    public sealed partial class JsonSchemaWriter : IDisposable, IAsyncDisposable
    {
        private readonly Utf8JsonWriter writer;
        private readonly JsonSerializerOptions? options;
        private bool disposed;

        public JsonSchemaWriter(Stream stream, JsonSerializerOptions? options = null)
        {
            writer = new Utf8JsonWriter(stream, GetWriterOptions(options));
            this.options = options;
        }

        public void Write(JsonSchemaElement element)
        {
            Visit(element);
        }

        public void Dispose()
        {
            if (disposed)
                return;

            disposed = true;
            writer.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            if (disposed)
                return;

            disposed = true;
            await writer.DisposeAsync();
        }

        /// <summary>
        /// Commits the Json Schema text written so far which makes it visible to the output destination.
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
        /// Asynchronously commits the Json Schema text written so far which makes it visible to the output destination.
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
