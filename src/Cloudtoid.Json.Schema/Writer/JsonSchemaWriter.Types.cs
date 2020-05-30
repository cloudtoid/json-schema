namespace Cloudtoid.Json.Schema
{
    public sealed partial class JsonSchemaWriter
    {
        protected internal override void VisitTypes(JsonSchemaTypes constraint)
        {
            base.VisitTypes(constraint);
            var len = constraint.Count;
            if (len == 1)
            {
                writer.WriteString(Keys.Type, constraint[0].GetEncodedTypeName());
                return;
            }

            writer.WriteStartArray(Keys.Type);

            for (int i = 0; i < len; i++)
                writer.WriteStringValue(constraint[i].GetEncodedTypeName());

            writer.WriteEndArray();
        }
    }
}
