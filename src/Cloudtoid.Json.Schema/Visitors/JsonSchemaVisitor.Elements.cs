namespace Cloudtoid.Json.Schema
{
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
        }

        protected virtual void VisitMetadata(JsonSchemaMetadata metadata)
        {
            // no-op
        }

        protected internal virtual void VisitSchema(JsonSchema element)
            => VisitElement(element);

        protected internal virtual void VisitChildElement(JsonSchemaChildElement element)
            => VisitElement(element);
    }
}
