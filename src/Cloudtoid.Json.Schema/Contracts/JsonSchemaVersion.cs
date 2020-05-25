namespace Cloudtoid.Json.Schema
{
    public enum JsonSchemaVersion
    {
        /// <summary>
        /// The schema is not specified.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// The schema version is specified, but it is not recognized.
        /// </summary>
        Unknown = 1,

        /// <summary>
        ///  Draft 3 of the RFC
        /// </summary>
        Draft03 = 3,

        /// <summary>
        ///  Draft 4 of the RFC
        /// </summary>
        Draft04 = 4,

        /// <summary>
        ///  Draft 6 of the RFC
        /// </summary>
        Draft06 = 6,

        /// <summary>
        ///  Draft 7 of the RFC
        /// </summary>
        Draft07 = 7,

        /// <summary>
        /// Draft published 2019-09
        /// </summary>
        Draft201909 = 8,
    }
}
