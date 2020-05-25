namespace Cloudtoid.Json.SchemaNew
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Text.Json;
    using static Contract;

    public abstract class JsonSchemaConstraint
    {
    }

    public class JsonSchemaConstraints : JsonSchemaConstraint
    {
        public static readonly JsonSchemaConstraints Empty = new JsonSchemaConstraints(Array.Empty<JsonSchemaConstraint>());

        public JsonSchemaConstraints(IReadOnlyCollection<JsonSchemaConstraint> constraints)
        {
            Constraints = CheckAllValues(constraints, nameof(constraints));
        }

        public virtual IReadOnlyCollection<JsonSchemaConstraint> Constraints { get; }
    }

    public class JsonSchemaNot : JsonSchemaConstraint
    {
        public JsonSchemaNot(JsonSchemaConstraint not)
        {
            Not = CheckValue(not, nameof(not));
        }

        public JsonSchemaConstraint Not { get; }
    }

    public class JsonSchemaIfThenElse : JsonSchemaConstraint
    {
        public JsonSchemaIfThenElse(
            JsonSchemaConstraint @if,
            JsonSchemaConstraint then,
            JsonSchemaConstraint? @else)
        {
            If = CheckValue(@if, nameof(@if));
            Then = CheckValue(then, nameof(then));
            Else = @else;
        }

        public JsonSchemaConstraint If { get; }

        public JsonSchemaConstraint Then { get; }

        public JsonSchemaConstraint? Else { get; }
    }

    public class JsonSchemaAnyOf : JsonSchemaConstraints
    {
        public JsonSchemaAnyOf(IReadOnlyCollection<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }
    }

    public class JsonSchemaOneOf : JsonSchemaConstraints
    {
        public JsonSchemaOneOf(IReadOnlyCollection<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }
    }

    public class JsonSchemaAllOf : JsonSchemaConstraints
    {
        public JsonSchemaAllOf(IReadOnlyCollection<JsonSchemaConstraint> constraints)
            : base(constraints)
        {
        }
    }

    public class JsonSchemaTypeConstraint : JsonSchemaConstraint
    {
        public JsonSchemaTypeConstraint(JsonSchemaType type)
        {
            Type = type;
        }

        public JsonSchemaType Type { get; }
    }

    public class JsonSchemaConstant : JsonSchemaConstraint
    {
        public JsonSchemaConstant(JsonElement element)
        {
            CheckNotEqual(element.ValueKind, JsonValueKind.Undefined, nameof(element.ValueKind));
            Element = element;
        }

        public JsonElement Element { get; }
    }

    public class JsonSchemaEnum : JsonSchemaAnyOf
    {
        public JsonSchemaEnum(IReadOnlyCollection<JsonSchemaConstant> constraints)
            : base(constraints)
        {
        }
    }

    // the following restrictions can only be applied to json values of type string
    public class JsonSchemaStringConstraint : JsonSchemaConstraint
    {
        public JsonSchemaStringConstraint(
            uint? minLength,
            uint? maxLength,
            string? pattern,
            string? format,
            string? contentEncoding,
            string? contentMediaType)
        {
            MinLength = minLength;
            MaxLength = maxLength;
            Pattern = pattern;
            Format = format;
            ContentEncoding = contentEncoding;
            ContentMediaType = contentMediaType;
        }

        /// <summary>
        /// Gets the minimum length of the string. It uses the <c>minLength</c> keyword and its value must be a non-negative number.
        /// </summary>
        public uint? MinLength { get; }

        /// <summary>
        /// Gets the maximum length of the string. It uses the <c>maxLength</c> keyword and its value must be a non-negative number.
        /// </summary>
        public uint? MaxLength { get; }

        /// <summary>
        /// Gets the regular expression pattern that is used to restrict the value of this string.
        /// The complex syntax of regular expression in JavaScript is supported here, but that complete syntax is not widely supported.
        /// Therefore, it is recommended to use the subset of that syntax described <a href="https://json-schema.org/understanding-json-schema/reference/regular_expressions.html#regular-expressions">here</a>.
        /// </summary>
        public string? Pattern { get; }

        /// <summary>
        /// Gets the format string which enforces basic semantic validation on certain kinds of string values that are commonly used.
        /// This allows values to be constrained beyond what the other tools in JSON Schema, including <see cref="Pattern"/> can do.
        /// <list type="bullet">
        /// <item><term>date</term></item>A string is valid against this format if it represents a date in the following format: <c>YYYY-MM-DD</c>.
        /// <item><term>time</term>A string is valid against this format if it represents a time in the following format: <c>hh:mm:ss.sTZD</c>.</item>
        /// <item><term>date-time</term>A string is valid against this format if it represents a date-time in the following format<c></c>.</item>
        /// <item><term>regex</term>A string is valid against this format if it represents a valid regular expression.</item>
        /// <item><term>email</term>A string is valid against this format if it represents a valid e-mail address format.</item>
        /// <item><term>idn-email</term>A string is valid against this format if it represents a valid IDN e-mail address format.</item>
        /// <item><term>hostname</term>A string is valid against this format if it represents a valid hostname.</item><c></c>.
        /// <item><term>idn-hostname</term>A string is valid against this format if it represents a valid IDN hostname.</item>
        /// <item><term>ipv4</term>A string is valid against this format if it represents a valid IPv4 address.</item>
        /// <item><term>ipv6</term>A string is valid against this format if it represents a valid IPv6 address.</item>
        /// <item><term>json-pointer</term>A string is valid against this format if it represents a valid (absolute) json pointer.</item>
        /// <item><term>relative-json-pointer</term>A string is valid against this format if it represents a valid relative json pointer.</item>
        /// <item><term>uri</term>A string is valid against this format if it represents a valid uri.</item>
        /// <item><term>uri-reference</term>A string is valid against this format if it represents a valid uri or uri reference.</item>
        /// <item><term>uri-template</term>A string is valid against this format if it represents a valid uri template or uri-reference.</item>
        /// <item><term>iri</term>A string is valid against this format if it represents a valid IRI.</item>
        /// <item><term>iri-reference</term>A string is valid against this format if it represents a valid IRI reference.</item>
        /// </list>
        /// </summary>
        public string? Format { get; }

        /// <summary>
        /// Gets the encoding that is used to restrict the value of this string.
        /// The acceptable values are <c>7bit</c>, <c>8bit</c>, <c>binary</c>, <c>quoted-printable</c> and <c>base64</c>. If not specified,
        /// the encoding is the same as the containing JSON document.
        /// </summary>
        public string? ContentEncoding { get; }

        /// <summary>
        /// Gets the <c>contentMediaType</c> keyword specifies the MIME type of the contents of a string, as described in RFC 2046.
        /// There is a list of MIME types officially registered by the IANA, but the set of types supported will be application and operating
        /// system dependent.
        /// </summary>
        public string? ContentMediaType { get; }
    }

    // the following restrictions can only be applied to json values of type number
    public class JsonSchemaNumberConstraint : JsonSchemaConstraint
    {
        public JsonSchemaNumberConstraint(
            double? multipleOf,
            JsonSchemaNumberRange? range)
        {
            MultipleOf = multipleOf is null ? default : CheckGreaterThan(multipleOf.Value, 0.0, nameof(multipleOf));
            Range = range;
        }

        /// <summary>
        /// Gets a multiple of a given number to restrict the valid values.
        /// This uses the <c>multipleOf</c> keyword and may only be a positive number.
        /// </summary>
        public double? MultipleOf { get; }

        /// <summary>
        /// Gets the valid range for this number using a combination of the <c>minimum</c>,
        /// <c>exclusiveMinimum</c>, <c>maximum</c>, and <c>exclusiveMaximum</c> keywords.
        /// </summary>
        public JsonSchemaNumberRange? Range { get; }
    }

    // the following restrictions can only be applied to json values of type integer
    public class JsonSchemaIntegerConstraint : JsonSchemaConstraint
    {
        public JsonSchemaIntegerConstraint(
            int? multipleOf,
            JsonSchemaIntegerRange? range)
        {
            MultipleOf = multipleOf is null ? default : CheckGreaterThan(multipleOf.Value, 0, nameof(multipleOf));
            Range = range;
        }

        /// <summary>
        /// Gets a multiple of a given number to restrict the valid values.
        /// This uses the <c>multipleOf</c> keyword and may only be a positive number.
        /// </summary>
        public int? MultipleOf { get; }

        /// <summary>
        /// Gets the valid range for this number using a combination of the <c>minimum</c>,
        /// <c>exclusiveMinimum</c>, <c>maximum</c>, and <c>exclusiveMaximum</c> keywords.
        /// </summary>
        public JsonSchemaIntegerRange? Range { get; }
    }

    // the following restrictions can only be applied to json values of type object
    public class JsonSchemaObjectConstraint : JsonSchemaConstraint
    {
        public JsonSchemaObjectConstraint(
            IReadOnlyDictionary<string, JsonSchemaElement>? properties,
            ISet<string>? requiredProperties,
            IReadOnlyDictionary<string, JsonSchemaElement>? patternProperties,
            JsonSchemaStringConstraint? propertyNames,
            int? minProperties,
            int? maxProperties)
        {
            Properties = properties ?? ImmutableDictionary<string, JsonSchemaElement>.Empty;
            RequiredProperties = requiredProperties ?? ImmutableHashSet<string>.Empty;
            PatternProperties = patternProperties ?? ImmutableDictionary<string, JsonSchemaElement>.Empty;
            PropertyNames = propertyNames;
            MinProperties = minProperties is null ? default : CheckNonNegative(minProperties.Value, nameof(minProperties));
            MaxProperties = maxProperties is null ? default : CheckNonNegative(maxProperties.Value, nameof(maxProperties));
        }

        /// <summary>
        /// Gets the properties of this object.
        /// An object is valid against this value if every property that is present in both the object and the value of this keyword,
        /// validates against the corresponding schema. The value of this keyword must be an object, where properties must contain valid
        /// json schemas (objects or booleans). Only the property names that are present in both the object and the keyword value are checked.
        /// </summary>
        public IReadOnlyDictionary<string, JsonSchemaElement> Properties { get; }

        /// <summary>
        /// Gets the names of the required properties of this object.
        /// An object is valid against this value if it contains all property names specified by the value.
        /// </summary>
        public ISet<string> RequiredProperties { get; }

        /// <summary>
        /// Gets the properties of this object.
        /// An object is valid against this constraint if every property where a property name  matches a regular expression from this value,
        /// is also valid against the corresponding schema. Only the property names that are present here and in the object instance are checked.
        /// </summary>
        public IReadOnlyDictionary<string, JsonSchemaElement> PatternProperties { get; }

        /// <summary>
        /// Gets the constraint applied to all property names of this object.
        /// An object is valid against this constraint if every property name is valid against this value.
        /// </summary>
        public JsonSchemaStringConstraint? PropertyNames { get; }

        /// <summary>
        /// Gets the minimum number of properties.
        /// An object is valid against this value if the number of properties it contains is greater then, or equal to, the value of this keyword.
        /// The value of this keyword must be a non-negative integer.
        /// </summary>
        public int? MinProperties { get; }

        /// <summary>
        /// Gets the maximum number of properties.
        /// An object is valid against this value if the number of properties it contains is lower then, or equal to, the value of this keyword.
        /// The value of this keyword must be a non-negative integer.
        /// </summary>
        public int? MaxProperties { get; }

        // TODO: Add dependencies and additionalProperties
    }

    // the following restrictions can only be applied to json values of type array
    public class JsonSchemaArrayConstraint : JsonSchemaConstraint
    {
        public JsonSchemaArrayConstraint(
            int? minsItems,
            int? maxItems,
            bool? uniqueItems,
            JsonSchemaElement? contains,
            JsonSchemaArrayItemsConstraint? items)
        {
            MinItems = minsItems is null ? default : CheckNonNegative(minsItems.Value, nameof(minsItems));
            MaxItems = maxItems is null ? default : CheckNonNegative(maxItems.Value, nameof(maxItems));
            UniqueItems = uniqueItems;
            Contains = contains;
            Items = items;
        }

        /// <summary>
        /// Gets the minimum number of items in the array.
        /// An array is valid against this value, if the number of items it contains is greater than, or equal to, this value.
        /// This value must be a non-negative integer.
        /// </summary>
        public int? MinItems { get; }

        /// <summary>
        /// Gets the maximum number of items in the array.
        /// An array is valid against this value, if the number of items it contains is less than, or equal to, this value.
        /// This value must be a non-negative integer.
        /// </summary>
        public int? MaxItems { get; }

        /// <summary>
        /// Gets the value that indicates all items in this array must be unique.
        /// </summary>
        public bool? UniqueItems { get; }

        /// <summary>
        /// Gets a json schema element.
        /// An array is valid against this element if at least one item is valid against the schema defined by this value.
        /// The value of this keyword must be a valid json schema element (object or boolean).
        /// </summary>
        public JsonSchemaElement? Contains { get; }

        /// <summary>
        /// Gets the item constraints.
        /// An array is valid against this value if items are valid against the corresponding schemas provided here. This value can be
        /// <list type="bullet">
        /// <item>a valid json schema element (object or boolean), then every item must be valid against this schema. In this case,
        /// this property will be set to an instance of <see cref="JsonSchemaArraySingleItemConstraint"/></item>
        /// <item>an array of valid json schemas, then each item must be valid against the schema defined at the same position(index).
        /// Items that don’t have a corresponding position (array contains 5 items and this value only has 3) will be considered valid,
        /// unless the additionalItems keyword is present - which will decide the validity. In this case, this property will be set to
        /// an instance of <see cref="JsonSchemaArrayArrayItemConstraint"/></item>
        /// </list>
        /// </summary>
        public JsonSchemaArrayItemsConstraint? Items { get; }
    }

    // the following restrictions can only be applied to json values of type array
    public abstract class JsonSchemaArrayItemsConstraint : JsonSchemaConstraint
    {
    }

    public class JsonSchemaArraySingleItemConstraint : JsonSchemaArrayItemsConstraint
    {
        public JsonSchemaArraySingleItemConstraint(
            JsonSchemaElement item)
        {
            Item = CheckValue(item, nameof(item));
        }

        public JsonSchemaElement Item { get; }
    }

    public class JsonSchemaArrayArrayItemConstraint : JsonSchemaArrayItemsConstraint
    {
        public JsonSchemaArrayArrayItemConstraint(
            IReadOnlyCollection<JsonSchemaElement> items,
            JsonSchemaElement? additionalItems)
        {
            Items = CheckValue(items, nameof(items));
            AdditionalItems = additionalItems;
        }

        public IReadOnlyCollection<JsonSchemaElement> Items { get; }

        public JsonSchemaElement? AdditionalItems { get; }
    }
}
