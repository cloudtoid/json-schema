﻿using System.Text.Json;

namespace Cloudtoid.Json.Schema
{
    public sealed partial class JsonSchemaWriter
    {
        private static class Keys
        {
            // core keys

            internal static readonly JsonEncodedText Id = JsonEncodedText.Encode("$id");
            internal static readonly JsonEncodedText Anchor = JsonEncodedText.Encode("$anchor");
            internal static readonly JsonEncodedText RecursiveAnchor = JsonEncodedText.Encode("$recursiveAnchor");
            internal static readonly JsonEncodedText Ref = JsonEncodedText.Encode("$ref");
            internal static readonly JsonEncodedText RecursiveRef = JsonEncodedText.Encode("$recursiveRef");
            internal static readonly JsonEncodedText Schema = JsonEncodedText.Encode("$schema");
            internal static readonly JsonEncodedText Vocabulary = JsonEncodedText.Encode("$vocabulary");
            internal static readonly JsonEncodedText Comment = JsonEncodedText.Encode("$comment");
            internal static readonly JsonEncodedText Defs = JsonEncodedText.Encode("$defs");

            // metadata keys

            internal static readonly JsonEncodedText Title = JsonEncodedText.Encode("title");
            internal static readonly JsonEncodedText Description = JsonEncodedText.Encode("description");
            internal static readonly JsonEncodedText Default = JsonEncodedText.Encode("default");
            internal static readonly JsonEncodedText Deprecated = JsonEncodedText.Encode("deprecated");
            internal static readonly JsonEncodedText ReadOnly = JsonEncodedText.Encode("readOnly");
            internal static readonly JsonEncodedText WriteOnly = JsonEncodedText.Encode("writeOnly");
            internal static readonly JsonEncodedText Examples = JsonEncodedText.Encode("examples");

            // type keys

            internal static readonly JsonEncodedText Type = JsonEncodedText.Encode("type");

            // number keys

            internal static readonly JsonEncodedText MultipleOf = JsonEncodedText.Encode("multipleOf");
            internal static readonly JsonEncodedText Minimum = JsonEncodedText.Encode("minimum");
            internal static readonly JsonEncodedText Maximum = JsonEncodedText.Encode("maximum");
            internal static readonly JsonEncodedText ExclusiveMinimum = JsonEncodedText.Encode("exclusiveMinimum");
            internal static readonly JsonEncodedText ExclusiveMaximum = JsonEncodedText.Encode("exclusiveMaximum");

            // named constraints keys

            internal static readonly JsonEncodedText AllOf = JsonEncodedText.Encode("allOf");
            internal static readonly JsonEncodedText AnyOf = JsonEncodedText.Encode("anyOf");
            internal static readonly JsonEncodedText OneOf = JsonEncodedText.Encode("oneOf");

            // string keys

            internal static readonly JsonEncodedText MinLength = JsonEncodedText.Encode("minLength");
            internal static readonly JsonEncodedText MaxLength = JsonEncodedText.Encode("maxLength");
            internal static readonly JsonEncodedText Pattern = JsonEncodedText.Encode("pattern");
            internal static readonly JsonEncodedText Format = JsonEncodedText.Encode("format");
            internal static readonly JsonEncodedText ContentEncoding = JsonEncodedText.Encode("contentEncoding");
            internal static readonly JsonEncodedText ContentMediaType = JsonEncodedText.Encode("contentMediaType");
            internal static readonly JsonEncodedText ContentSchema = JsonEncodedText.Encode("contentSchema");

            // object keys

            internal static readonly JsonEncodedText Properties = JsonEncodedText.Encode("properties");
            internal static readonly JsonEncodedText Required = JsonEncodedText.Encode("required");
            internal static readonly JsonEncodedText Dependencies = JsonEncodedText.Encode("dependencies");
            internal static readonly JsonEncodedText MinProperties = JsonEncodedText.Encode("minProperties");
            internal static readonly JsonEncodedText MaxProperties = JsonEncodedText.Encode("maxProperties");
            internal static readonly JsonEncodedText PropertyNames = JsonEncodedText.Encode("propertyNames");
            internal static readonly JsonEncodedText PatternProperties = JsonEncodedText.Encode("patternProperties");
            internal static readonly JsonEncodedText AdditionalProperties = JsonEncodedText.Encode("additionalProperties");

            // array keys

            internal static readonly JsonEncodedText MinItems = JsonEncodedText.Encode("minItems");
            internal static readonly JsonEncodedText MaxItems = JsonEncodedText.Encode("maxItems");
            internal static readonly JsonEncodedText UnniqueItems = JsonEncodedText.Encode("unniqueItems");
            internal static readonly JsonEncodedText Contains = JsonEncodedText.Encode("contains");
            internal static readonly JsonEncodedText MinContains = JsonEncodedText.Encode("minContains");
            internal static readonly JsonEncodedText MaxContains = JsonEncodedText.Encode("maxContains");
            internal static readonly JsonEncodedText Items = JsonEncodedText.Encode("items");
            internal static readonly JsonEncodedText AdditionalItems = JsonEncodedText.Encode("additionalItems");

            // conditional keys

            internal static readonly JsonEncodedText Not = JsonEncodedText.Encode("not");
            internal static readonly JsonEncodedText If = JsonEncodedText.Encode("if");
            internal static readonly JsonEncodedText Then = JsonEncodedText.Encode("then");
            internal static readonly JsonEncodedText Else = JsonEncodedText.Encode("else");

            // enum keys

            internal static readonly JsonEncodedText Enum = JsonEncodedText.Encode("enum");

            // const keys

            internal static readonly JsonEncodedText Const = JsonEncodedText.Encode("const");
        }
    }
}
