namespace Cloudtoid.Json.Schema
{
    public sealed partial class JsonSchemaWriter
    {
        protected internal override void VisitNumber(JsonSchemaNumber constraint)
        {
            base.VisitNumber(constraint);

            if (constraint.MultipleOf != null)
                writer.WriteNumber(Keys.MultipleOf, constraint.MultipleOf.Value);

            if (constraint.Minimum != null)
                writer.WriteNumber(constraint.IsMinimumExclusive ? Keys.ExclusiveMinimum : Keys.Minimum, constraint.Minimum.Value);

            if (constraint.Maximum != null)
                writer.WriteNumber(constraint.IsMaximumExclusive ? Keys.ExclusiveMaximum : Keys.Maximum, constraint.Maximum.Value);
        }

        protected internal override void VisitInteger(JsonSchemaInteger constraint)
        {
            base.VisitInteger(constraint);

            if (constraint.MultipleOf != null)
                writer.WriteNumber(Keys.MultipleOf, constraint.MultipleOf.Value);

            if (constraint.Minimum != null)
                writer.WriteNumber(constraint.IsMinimumExclusive ? Keys.ExclusiveMinimum : Keys.Minimum, constraint.Minimum.Value);

            if (constraint.Maximum != null)
                writer.WriteNumber(constraint.IsMaximumExclusive ? Keys.ExclusiveMaximum : Keys.Maximum, constraint.Maximum.Value);
        }
    }
}
