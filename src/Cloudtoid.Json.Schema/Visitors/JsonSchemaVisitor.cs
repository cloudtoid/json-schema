namespace Cloudtoid.Json.Schema
{
    public abstract partial class JsonSchemaVisitor
    {
        protected virtual void Visit(JsonSchemaConstraint constraint)
            => constraint.Accept(this);

        protected virtual void VisitConstraint(JsonSchemaConstraint constraint)
        {
            // no-op
        }

        protected internal virtual void VisitEnum(JsonSchemaEnum constraint)
            => VisitConstraint(constraint);

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
    }
}
