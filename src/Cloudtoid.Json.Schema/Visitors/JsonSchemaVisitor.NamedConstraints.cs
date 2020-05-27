namespace Cloudtoid.Json.Schema
{
    public abstract partial class JsonSchemaVisitor
    {
        protected virtual void VisitNamedConstraints(JsonSchemaNamedConstraints constraints)
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
    }
}
