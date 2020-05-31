namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public abstract partial class JsonSchemaVisitor
    {
        protected virtual void Visit(JsonSchemaResource resource)
            => resource.Accept(this);

        protected virtual void VisitResource(JsonSchemaResource resource)
        {
            if (resource.Constraints.Count > 0)
                VisitConstraints(resource.Constraints);

            if (!resource.Definitions.IsNullOrEmpty())
                VisitDefinitions(resource.Definitions);
        }

        protected virtual void VisitConstraints(JsonSchemaConstraints constraints)
        {
            foreach (var constraint in constraints)
                Visit(constraint);
        }

        protected virtual void VisitDefinitions(IDictionary<string, JsonSchemaSubSchema> resources)
        {
            foreach (var resource in resources)
                VisitDefinition(resource.Key, resource.Value);
        }

        protected virtual void VisitDefinition(string name, JsonSchemaSubSchema resource)
            => Visit(resource);

        protected internal virtual void VisitSchema(JsonSchema resource)
            => VisitResource(resource);

        protected internal virtual void VisitSubschema(JsonSchemaSubSchema resource)
            => VisitResource(resource);

        protected internal virtual void VisitOverride(JsonSchemaOverride resource)
            => VisitSubschema(resource);
    }
}
