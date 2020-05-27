namespace Cloudtoid.Json.Schema
{
    public sealed partial class JsonSchemaWriter
    {
        protected internal override void VisitNot(JsonSchemaNot constraint)
        {
            writer.WriteStartArray(Keys.Not);
            base.VisitNot(constraint);
            writer.WriteEndArray();
        }
    }
}
