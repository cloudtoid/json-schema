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
    public sealed class JsonSchemaWriter : IDisposable, IAsyncDisposable
    {
        private Utf8JsonWriter? writer;

        public JsonSchemaWriter(Stream stream, JsonWriterOptions options = default)
        {
            writer = new Utf8JsonWriter(stream, options);
        }

        public void Dispose()
        {
            if (writer is null)
                return;

            writer.Dispose();
            writer = null;
        }

        public async ValueTask DisposeAsync()
        {
            if (writer is null)
                return;

            await writer.DisposeAsync();
            writer = null;
        }

        /// <summary>
        /// Commits the Json Schema text written so far which makes it visible to the output destination.
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        ///   The instance of <see cref="JsonSchemaWriter"/> has been disposed.
        /// </exception>
        public void Flush()
            => GetSafeWriter().Flush();

        /// <summary>
        /// Asynchronously commits the Json Schema text written so far which makes it visible to the output destination.
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        ///   The instance of <see cref="JsonSchemaWriter"/> has been disposed.
        /// </exception>
        public async Task FlushAsync(CancellationToken cancellationToken = default)
            => await GetSafeWriter().FlushAsync(cancellationToken);

        private Utf8JsonWriter GetSafeWriter()
            => writer ?? throw new ObjectDisposedException(nameof(JsonSchemaWriter));
    }
}
