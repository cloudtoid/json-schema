namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public abstract partial class JsonSchemaVisitor
    {
        protected virtual void Visit(JsonSchemaElement element)
            => element.Accept(this);

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

            if (!element.Definitions.IsNullOrEmpty())
                VisitDefinitions(element.Definitions);
        }

        protected virtual void VisitDefinitions(IDictionary<string, JsonSchemaSubSchema> elements)
        {
            foreach (var element in elements)
                VisitDefinition(element.Key, element.Value);
        }

        protected virtual void VisitDefinition(string name, JsonSchemaSubSchema element)
            => Visit(element);

        protected virtual void VisitMetadata(JsonSchemaMetadata metadata)
        {
            // no-op
        }

        protected internal virtual void VisitSchema(JsonSchema element)
            => VisitElement(element);

        protected internal virtual void VisitChildElement(JsonSchemaSubSchema element)
            => VisitElement(element);
    }
}
