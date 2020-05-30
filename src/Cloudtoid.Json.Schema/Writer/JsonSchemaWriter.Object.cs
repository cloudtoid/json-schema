namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public sealed partial class JsonSchemaWriter
    {
        protected internal override void VisitObject(JsonSchemaObject constraint)
        {
            base.VisitObject(constraint);

            if (!constraint.RequiredProperties.IsNullOrEmpty())
                WriteObjectRequiredProperties(constraint.RequiredProperties);

            if (constraint.MinProperties != null)
                writer.WriteNumber(Keys.MinProperties, constraint.MinProperties.Value);

            if (constraint.MaxProperties != null)
                writer.WriteNumber(Keys.MaxProperties, constraint.MaxProperties.Value);
        }

        protected override void VisitObjectProperties(IDictionary<string, JsonSchemaSubSchema> properties)
        {
            writer.WriteStartObject(Keys.Properties);
            base.VisitObjectProperties(properties);
            writer.WriteEndObject();
        }

        protected override void VisitObjectProperty(string name, JsonSchemaSubSchema property)
        {
            writer.WriteStartObject(name);
            base.VisitObjectProperty(name, property);
            writer.WriteEndObject();
        }

        protected override void VisitObjectPatternProperties(IDictionary<string, JsonSchemaSubSchema> properties)
        {
            writer.WriteStartObject(Keys.PatternProperties);
            base.VisitObjectPatternProperties(properties);
            writer.WriteEndObject();
        }

        protected override void VisitObjectPatternProperty(string name, JsonSchemaSubSchema property)
        {
            writer.WriteStartObject(name);
            base.VisitObjectPatternProperty(name, property);
            writer.WriteEndObject();
        }

        protected override void VisitObjectAdditionalProperties(JsonSchemaSubSchema resource)
        {
            writer.WriteStartObject(Keys.AdditionalProperties);
            base.VisitObjectAdditionalProperties(resource);
            writer.WriteEndObject();
        }

        protected override void VisitObjectPropertyNames(JsonSchemaString constraint)
        {
            writer.WriteStartObject(Keys.PropertyNames);
            base.VisitObjectPropertyNames(constraint);
            writer.WriteEndObject();
        }

        private void WriteObjectRequiredProperties(ISet<string> requiredProperties)
        {
            writer.WriteStartArray(Keys.Required);

            foreach (var property in requiredProperties)
                writer.WriteStringValue(property);

            writer.WriteEndArray();
        }
    }
}
