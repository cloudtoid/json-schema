namespace Cloudtoid.Json.Schema
{
    using System.Text.Json;

    public sealed partial class JsonSchemaWriter
    {
        private static class Keys
        {
            // metadata keys

            internal static readonly JsonEncodedText Id = JsonEncodedText.Encode("$id");
            internal static readonly JsonEncodedText Title = JsonEncodedText.Encode("title");
            internal static readonly JsonEncodedText Description = JsonEncodedText.Encode("description");
            internal static readonly JsonEncodedText Default = JsonEncodedText.Encode("default");
            internal static readonly JsonEncodedText Examples = JsonEncodedText.Encode("examples");
            internal static readonly JsonEncodedText Comment = JsonEncodedText.Encode("$comment");
            internal static readonly JsonEncodedText Schema = JsonEncodedText.Encode("$schema");

            // type keys

            internal static readonly JsonEncodedText Type = JsonEncodedText.Encode("type");
        }
    }
}
