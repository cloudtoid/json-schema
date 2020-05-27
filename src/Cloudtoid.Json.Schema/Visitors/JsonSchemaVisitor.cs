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

        protected internal virtual void VisitNumber(JsonSchemaNumeric constraint)
            => VisitConstraint(constraint);

        protected internal virtual void VisitInteger(JsonSchemaInteger constraint)
            => VisitConstraint(constraint);

        protected internal virtual void VisitString(JsonSchemaString constraint)
        {
            // visit self
            VisitConstraint(constraint);

            // visit children
            if (constraint.ContentMediaType != null)
                VisitStringContentMedia(constraint.ContentMediaType, constraint.ContentSchema);
        }

        protected virtual void VisitStringContentMedia(string contentMediaType, JsonSchemaSubSchema? contentSchema)
        {
            if (contentSchema != null)
                VisitStringContentSchema(contentSchema);
        }

        protected virtual void VisitStringContentSchema(JsonSchemaSubSchema element)
            => Visit(element);
    }
}
