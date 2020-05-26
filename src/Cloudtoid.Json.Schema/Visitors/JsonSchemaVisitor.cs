namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public abstract class JsonSchemaVisitor
    {
        protected virtual void Visit(JsonSchemaElement element)
            => element.Accept(this);

        protected virtual void Visit(JsonSchemaConstraint constraint)
            => constraint.Accept(this);

        protected virtual void Visit(JsonSchemaArrayItems items)
            => items.Accept(this);

        protected virtual void VisitElement(JsonSchemaElement element)
        {
            if (element.Metadata != null)
                VisitMetadata(element.Metadata);

            var constraints = element.Constraints;
            if (constraints.Count > 0)
            {
                foreach (var constraint in constraints)
                    Visit(constraint);
            }
        }

        protected virtual void VisitMetadata(JsonSchemaMetadata metadata)
        {
            // no-op
        }

        protected internal virtual void VisitSchema(JsonSchema element)
            => VisitElement(element);

        protected internal virtual void VisitChildElement(JsonSchemaChildElement element)
            => VisitElement(element);

        protected virtual void VisitConstraint(JsonSchemaConstraint constraint)
        {
            // no-op
        }

        protected void VisitNamedConstraints(JsonSchemaNamedConstraints constraints)
        {
            // visit self
            VisitConstraint(constraints);

            // visit children
            foreach (var constraint in constraints)
                Visit(constraint);
        }

        protected internal virtual void VisitOne(JsonSchemaOne constraints)
            => VisitNamedConstraints(constraints);

        protected internal virtual void VisitAll(JsonSchemaAll constraints)
            => VisitNamedConstraints(constraints);

        protected internal virtual void VisitAny(JsonSchemaAny constraints)
            => VisitNamedConstraints(constraints);

        protected internal virtual void VisitEnum(JsonSchemaEnum constraint)
            => VisitAny(constraint);

        protected internal virtual void VisitConditional(JsonSchemaConditional constraint)
        {
            // visit self
            VisitConstraint(constraint);

            // visit children

            Visit(constraint.If);
            Visit(constraint.Then);

            if (constraint.Else != null)
                Visit(constraint.Else);
        }

        protected internal virtual void VisitNot(JsonSchemaNot constraint)
        {
            // visit self
            VisitConstraint(constraint);

            // visit children
            Visit(constraint.Not);
        }

        protected internal virtual void VisitConstant(JsonSchemaConstant constraint)
            => VisitConstraint(constraint);

        protected internal virtual void VisitTypes(JsonSchemaTypes constraint)
            => VisitConstraint(constraint);

        protected internal virtual void VisitNumber(JsonSchemaNumber constraint)
            => VisitConstraint(constraint);

        protected internal virtual void VisitInteger(JsonSchemaInteger constraint)
            => VisitConstraint(constraint);

        protected internal virtual void VisitString(JsonSchemaString constraint)
            => VisitConstraint(constraint);

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

        protected internal virtual void VisitArray(JsonSchemaArray constraint)
        {
            // visit self
            VisitConstraint(constraint);

            // visit children

            if (constraint.Contains != null)
                Visit(constraint.Contains);

            if (constraint.Items != null)
                Visit(constraint.Items);
        }

        protected virtual void VisitArraySingleItem(JsonSchemaArrayItems items)
        {
            // no-op
        }

        protected internal virtual void VisitArraySingleItem(JsonSchemaArraySingleItem item)
        {
            // visit self
            VisitArraySingleItem(item);

            // visit children

            Visit(item.Item);
        }

        protected internal virtual void VisitArrayArrayItems(JsonSchemaArrayArrayItems items)
        {
            // visit self
            VisitArraySingleItem(items);

            // visit children

            foreach (var item in items.Items)
                Visit(item);

            if (items.AdditionalItems != null)
                Visit(items.AdditionalItems);
        }
    }
}
