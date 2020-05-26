namespace Cloudtoid.Json.Schema
{
    public sealed partial class JsonSchemaWriter
    {
        protected internal override void VisitNumber(JsonSchemaNumber constraint)
        {
            base.VisitNumber(constraint);

            if (constraint.MultipleOf != null)
                writer.WriteNumber(Keys.MultipleOf, constraint.MultipleOf.Value);
        }
    }
}
