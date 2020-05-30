namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    // the following restrictions can only be applied to JSON values of type object
    public class JsonSchemaObject : JsonSchemaConstraint
    {
        public JsonSchemaObject(
            IDictionary<string, JsonSchemaSubSchema>? properties = null,
            IDictionary<string, JsonSchemaSubSchema>? patternProperties = null,
            JsonSchemaSubSchema? additionalProperties = null,
            JsonSchemaString? propertyNames = null,
            ISet<string>? requiredProperties = null,
            uint? minProperties = null,
            uint? maxProperties = null)
        {
            Properties = new ValueDictionary<string, JsonSchemaSubSchema>(properties);
            PatternProperties = new ValueDictionary<string, JsonSchemaSubSchema>(patternProperties);
            AdditionalProperties = additionalProperties;
            PropertyNames = propertyNames;
            RequiredProperties = new ValueSet<string>(requiredProperties);
            MinProperties = minProperties;
            MaxProperties = maxProperties;
        }

        public JsonSchemaObject()
            : this(null)
        {
        }

        /// <summary>
        /// Gets or sets the property collection of this object.
        /// An object is valid against this value if every property that is present in both the object and the value of this keyword,
        /// validates against the corresponding schema. The value of this keyword must be an object, where properties must contain valid
        /// JSON schemas (objects or booleans). Only the property names that are present in both the object and the keyword value are checked.
        /// </summary>
        public virtual IDictionary<string, JsonSchemaSubSchema> Properties { get; set; }

        /// <summary>
        /// Gets or sets the properties of this object.
        /// An object is valid against this constraint if every property where a property name  matches a regular expression from this value,
        /// is also valid against the corresponding schema. Only the property names that are present here and in the object instance are checked.
        /// </summary>
        public virtual IDictionary<string, JsonSchemaSubSchema> PatternProperties { get; set; }

        /// <summary>
        /// Gets or sets the additional properties constraints.
        /// An object is valid against this constraint if all unchecked properties are valid against the schema defined by this value.
        /// Unchecked properties are the properties not checked by the <see cref="Properties"/> and <see cref="PatternProperties"/>.
        /// If <see cref="Properties"/> is empty and there are no matches against the patterns of <see cref="PatternProperties"/>, then
        /// it is considered unchecked. The value of this keyword must be a valid JSON schema element (object or boolean).
        /// </summary>
        /// <remarks>
        /// To be more concise, if we have unchecked properties:
        /// <list type="bullet">
        /// <item>if the value is <see langword="true"/>, it is always valid</item>
        /// <item>if the value is <see langword="false"/>, is never valid</item>
        /// <item>if the value contains a schema element, every property must be valid against that schema element.</item>
        /// </list>
        /// </remarks>
        public virtual JsonSchemaSubSchema? AdditionalProperties { get; set; }

        /// <summary>
        /// Gets or sets the constraint applied to all property names of this object.
        /// An object is valid against this constraint if every property name is valid against this value.
        /// </summary>
        public virtual JsonSchemaString? PropertyNames { get; set; }

        /// <summary>
        /// Gets or sets the names of the required properties of this object.
        /// An object is valid against this value if it contains all property names specified by the value.
        /// </summary>
        public virtual ISet<string> RequiredProperties { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of properties.
        /// An object is valid against this value if the number of properties it contains is greater then, or equal to, the value of this keyword.
        /// The value of this property must be a non-negative integer.
        /// </summary>
        public virtual uint? MinProperties { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of properties.
        /// An object is valid against this value if the number of properties it contains is lower then, or equal to, the value of this keyword.
        /// The value of this property must be a non-negative integer.
        /// </summary>
        public virtual uint? MaxProperties { get; set; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitObject(this);
    }
}
