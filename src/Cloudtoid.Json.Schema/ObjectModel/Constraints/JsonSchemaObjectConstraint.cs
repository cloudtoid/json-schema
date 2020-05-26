﻿namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using static Contract;

    // the following restrictions can only be applied to json values of type object
    public class JsonSchemaObjectConstraint : JsonSchemaConstraint
    {
        public JsonSchemaObjectConstraint(
            IReadOnlyDictionary<string, JsonSchemaElement>? properties,
            IReadOnlyDictionary<string, JsonSchemaElement>? patternProperties,
            JsonSchemaElement? additionalProperties,
            JsonSchemaStringConstraint? propertyNames,
            ISet<string>? requiredProperties,
            int? minProperties,
            int? maxProperties)
        {
            Properties = properties ?? ImmutableDictionary<string, JsonSchemaElement>.Empty;
            PatternProperties = patternProperties ?? ImmutableDictionary<string, JsonSchemaElement>.Empty;
            AdditionalProperties = additionalProperties;
            PropertyNames = propertyNames;
            RequiredProperties = requiredProperties ?? ImmutableHashSet<string>.Empty;
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
        /// Gets the properties of this object.
        /// An object is valid against this constraint if every property where a property name  matches a regular expression from this value,
        /// is also valid against the corresponding schema. Only the property names that are present here and in the object instance are checked.
        /// </summary>
        public IReadOnlyDictionary<string, JsonSchemaElement> PatternProperties { get; }

        /// <summary>
        /// Gets the additional properties constraints.
        /// An object is valid against this constraint if all unchecked properties are valid against the schema defined by this value.
        /// Unchecked properties are the properties not checked by the <see cref="Properties"/> and <see cref="PatternProperties"/>.
        /// If <see cref="Properties"/> is empty and there are no matches against the patterns of <see cref="PatternProperties"/>, then
        /// it is considered unchecked. The value of this keyword must be a valid json schema element (object or boolean).
        /// </summary>
        /// <remarks>
        /// To be more concise, if we have unchecked properties:
        /// <list type="bullet">
        /// <item>if the value is <see langword="true"/>, it is always valid</item>
        /// <item>if the value is <see langword="false"/>, is never valid</item>
        /// <item>if the value contains a schema element, every property must be valid against that schema element.</item>
        /// </list>
        /// </remarks>
        public JsonSchemaElement? AdditionalProperties { get; }

        /// <summary>
        /// Gets the constraint applied to all property names of this object.
        /// An object is valid against this constraint if every property name is valid against this value.
        /// </summary>
        public JsonSchemaStringConstraint? PropertyNames { get; }

        /// <summary>
        /// Gets the names of the required properties of this object.
        /// An object is valid against this value if it contains all property names specified by the value.
        /// </summary>
        public ISet<string> RequiredProperties { get; }

        /// <summary>
        /// Gets the minimum number of properties.
        /// An object is valid against this value if the number of properties it contains is greater then, or equal to, the value of this keyword.
        /// The value of this property must be a non-negative integer.
        /// </summary>
        public int? MinProperties { get; }

        /// <summary>
        /// Gets the maximum number of properties.
        /// An object is valid against this value if the number of properties it contains is lower then, or equal to, the value of this keyword.
        /// The value of this property must be a non-negative integer.
        /// </summary>
        public int? MaxProperties { get; }
    }
}