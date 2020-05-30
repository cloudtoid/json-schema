namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    public abstract partial class JsonSchemaVisitor
    {
        protected virtual void Visit(JsonSchemaResource resource)
            => resource.Accept(this);

        protected virtual void VisitResource(JsonSchemaResource resource)
        {
            var constraints = resource.Constraints;
            if (constraints.Count > 0)
            {
                foreach (var constraint in constraints)
                    Visit(constraint);
            }

            if (!resource.Definitions.IsNullOrEmpty())
                VisitDefinitions(resource.Definitions);
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
    }
}
