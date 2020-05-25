namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="JsonSchemaTypes"/> is an array of <see cref="JsonSchemaType"/>
    /// The <c>type</c> keyword may either be a string or an array:
    /// <list type="bullet">
    /// <item>If it’s a string, it is the name of one of the basic types such as number, array, or string.</item>
    /// <item>If it is an array, it must be an array of strings, where each string is the name of one of the basic types, and each element is unique. In this case, the JSON snippet is valid if it matches any of the given types.</item>
    /// </list>
    /// </summary>
    public class JsonSchemaTypes : List<JsonSchemaType>
    {
    }
}
