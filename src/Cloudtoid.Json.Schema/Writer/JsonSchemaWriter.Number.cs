namespace Cloudtoid.Json.Schema
{
    public sealed partial class JsonSchemaWriter
    {
        protected internal override void VisitNumber(JsonSchemaNumber constraint)
        {
            base.VisitNumber(constraint);

            if (constraint.MultipleOf != null)
                writer.WriteNumber(Keys.MultipleOf, constraint.MultipleOf.Value);

            var range = constraint.Range;
            if (range is null)
                return;

            var minimum = range.Minimum;
            if (minimum != null)
            {
                var min = minimum.Value;
                writer.WriteNumber(min.Exclusive ? Keys.ExclusiveMinimum : Keys.Minimum, min.Value);
            }

            var maximum = range.Maximum;
            if (maximum != null)
            {
                var max = maximum.Value;
                writer.WriteNumber(max.Exclusive ? Keys.ExclusiveMaximum : Keys.Maximum, max.Value);
            }
        }

        protected internal override void VisitInteger(JsonSchemaInteger constraint)
        {
            base.VisitInteger(constraint);

            if (constraint.MultipleOf != null)
                writer.WriteNumber(Keys.MultipleOf, constraint.MultipleOf.Value);

            var range = constraint.Range;
            if (range is null)
                return;

            var minimum = range.Minimum;
            if (minimum != null)
            {
                var min = minimum.Value;
                writer.WriteNumber(min.Exclusive ? Keys.ExclusiveMinimum : Keys.Minimum, min.Value);
            }

            var maximum = range.Maximum;
            if (maximum != null)
            {
                var max = maximum.Value;
                writer.WriteNumber(max.Exclusive ? Keys.ExclusiveMaximum : Keys.Maximum, max.Value);
            }
        }
    }
}
