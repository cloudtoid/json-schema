namespace Cloudtoid.Json.Schema
{
    public abstract partial class JsonSchemaVisitor
    {
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
