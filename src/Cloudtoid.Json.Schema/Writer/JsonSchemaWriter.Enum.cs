namespace Cloudtoid.Json.Schema
{
    public sealed partial class JsonSchemaWriter
    {
        protected internal override void VisitEnum(JsonSchemaEnum constraint)
        {
            writer.WriteStartArray(Keys.Enum);
            base.VisitEnum(constraint);
            writer.WriteEndArray();
        }
    }
}
