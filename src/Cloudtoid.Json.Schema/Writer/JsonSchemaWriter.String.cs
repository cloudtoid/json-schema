namespace Cloudtoid.Json.Schema
{
    public sealed partial class JsonSchemaWriter
    {
        protected internal override void VisitString(JsonSchemaString constraint)
        {
            if (constraint.MinLength != null)
                writer.WriteNumber(Keys.MinLength, constraint.MinLength.Value);

            if (constraint.MaxLength != null)
                writer.WriteNumber(Keys.MaxLength, constraint.MaxLength.Value);

            if (constraint.Pattern != null)
                writer.WriteString(Keys.Pattern, constraint.Pattern);

            if (constraint.Format != null)
                writer.WriteString(Keys.Format, constraint.Format);

            if (constraint.ContentEncoding != null)
                writer.WriteString(Keys.ContentEncoding, constraint.ContentEncoding);

            base.VisitString(constraint);
        }

        protected override void VisitStringContentMedia(string contentMediaType, JsonSchemaSubSchema? contentSchema)
        {
            writer.WriteString(Keys.ContentMediaType, contentMediaType);
            base.VisitStringContentMedia(contentMediaType, contentSchema);
        }

        protected override void VisitStringContentSchema(JsonSchemaSubSchema element)
        {
            writer.WriteStartObject(Keys.ContentSchema);
            base.VisitStringContentSchema(element);
            writer.WriteEndObject();
        }
    }
}
