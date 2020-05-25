namespace Cloudtoid.Json.Schema
{
    public enum JsonSchemaTypeKind : byte
    {
        /// <summary>
        /// The kind is not specified.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// The kind is set, but it is not recognized.
        /// </summary>
        Unknown = 1,

        Null = 2,
        Object = 3,
        Array = 4,
        String = 5,
        Number = 6,
        Boolean = 7,
    }
}
