namespace Cloudtoid.Json.Schema
{
    public sealed partial class JsonSchemaWriter
    {
        protected internal override void VisitAll(JsonSchemaAll constraints)
        {
            writer.WriteStartObject(Keys.AllOf);
            base.VisitAll(constraints);
            writer.WriteEndObject();
        }

        protected internal override void VisitAny(JsonSchemaAny constraints)
        {
            writer.WriteStartObject(Keys.AnyOf);
            base.VisitAny(constraints);
            writer.WriteEndObject();
        }

        protected internal override void VisitOne(JsonSchemaOne constraints)
        {
            writer.WriteStartObject(Keys.OneOf);
            base.VisitOne(constraints);
            writer.WriteEndObject();
        }
    }
}
