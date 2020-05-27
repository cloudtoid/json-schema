namespace Cloudtoid.Json.Schema
{
    using System.Text.RegularExpressions;
    using static Contract;

    internal static class KeywordsContract
    {
        private static readonly RegexOptions RegexOption =
            RegexOptions.Compiled
            | RegexOptions.Singleline
            | RegexOptions.CultureInvariant
            | RegexOptions.ExplicitCapture;

        private static readonly Regex AnchorRegex = new Regex(@"^[A-Za-z_][-A-Za-z0-9._]*$", RegexOption);

        internal static string? CheckAnchor(string? value, string paramName)
        {
            CheckParam(
                value is null || AnchorRegex.IsMatch(value),
                paramName,
                "A valid anchor value MUST be a string, which must start with a letter ([A-Za-z]), followed by any number of letters, digits ([0-9]), hyphens (-), underscores (_), colons (:), or periods (.).");

            return value;
        }
    }
}
