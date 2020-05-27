namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public abstract partial class JsonSchemaVisitor
    {
        protected internal virtual void VisitObject(JsonSchemaObject constraint)
        {
            // visit self
            VisitConstraint(constraint);

            // visit children

            if (constraint.Properties.Count > 0)
                VisitObjectProperties(constraint.Properties);

            if (constraint.PatternProperties.Count > 0)
                VisitObjectPatternProperties(constraint.PatternProperties);

            if (constraint.AdditionalProperties != null)
                VisitObjectAdditionalProperties(constraint.AdditionalProperties);

            if (constraint.PropertyNames != null)
                VisitObjectPropertyNames(constraint.PropertyNames);
        }

        protected virtual void VisitObjectProperties(IReadOnlyDictionary<string, JsonSchemaChildElement> properties)
        {
            foreach (var property in properties)
                VisitObjectProperty(property.Key, property.Value);
        }

        protected virtual void VisitObjectProperty(string name, JsonSchemaChildElement property)
            => Visit(property);

        protected virtual void VisitObjectPatternProperties(IReadOnlyDictionary<string, JsonSchemaChildElement> properties)
        {
            foreach (var property in properties)
                VisitObjectPatternProperty(property.Key, property.Value);
        }

        protected virtual void VisitObjectPatternProperty(string name, JsonSchemaChildElement property)
            => Visit(property);

        protected virtual void VisitObjectAdditionalProperties(JsonSchemaChildElement element)
            => Visit(element);

        protected virtual void VisitObjectPropertyNames(JsonSchemaString constraint)
            => Visit(constraint);
    }
}
