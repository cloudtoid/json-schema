namespace Cloudtoid.Json.Schema
{
    public abstract partial class JsonSchemaVisitor
    {
        protected internal virtual void VisitString(JsonSchemaString constraint)
        {
            // visit self
            VisitConstraint(constraint);

            // visit children

            var media = constraint.ContentMedia;
            if (media != null)
                VisitStringContentMedia(media.Value);
        }

        protected virtual void VisitStringContentMedia(in JsonSchemaContentMedia media)
        {
            if (media.Schema != null)
                VisitStringContentSchema(media.Schema);
        }

        protected virtual void VisitStringContentSchema(JsonSchemaSubSchema element)
            => Visit(element);
    }
}
