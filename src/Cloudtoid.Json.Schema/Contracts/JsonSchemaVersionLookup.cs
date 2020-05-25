namespace Cloudtoid.Json.Schema
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public static class JsonSchemaVersionLookup
    {
        private const string Draft201909 = "http://json-schema.org/draft/2019-09/schema#";
        private const string Draft07 = "http://json-schema.org/draft-07/schema#";
        private const string Draft06 = "http://json-schema.org/draft-06/schema#";
        private const string Draft04 = "http://json-schema.org/draft-04/schema#";
        private const string Draft03 = "http://json-schema.org/draft-03/schema#";

        private static readonly IReadOnlyDictionary<string, JsonSchemaVersion> UriToVersion = new Dictionary<string, JsonSchemaVersion>(StringComparer.OrdinalIgnoreCase)
        {
            [Draft201909] = JsonSchemaVersion.Draft201909,
            [Draft07] = JsonSchemaVersion.Draft07,
            [Draft06] = JsonSchemaVersion.Draft06,
            [Draft04] = JsonSchemaVersion.Draft04,
            [Draft03] = JsonSchemaVersion.Draft03,
        };

        public static JsonSchemaVersion GetVersionFromSchemaUri(string? uri)
        {
            if (string.IsNullOrEmpty(uri))
                return JsonSchemaVersion.Unspecified;

            if (UriToVersion.TryGetValue(uri, out var version))
                return version;

            return JsonSchemaVersion.Unknown;
        }

        public static bool TryGetSchemaUri(
            this JsonSchemaVersion version,
            [NotNullWhen(true)] out string? uri)
        {
            uri = version switch
            {
                JsonSchemaVersion.Draft201909 => Draft201909,
                JsonSchemaVersion.Draft07 => Draft07,
                JsonSchemaVersion.Draft06 => Draft06,
                JsonSchemaVersion.Draft04 => Draft04,
                JsonSchemaVersion.Draft03 => Draft03,
                _ => null,
            };
            return uri != null;
        }
    }
}
