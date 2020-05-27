namespace Cloudtoid.Json.Schema
{
    public sealed partial class JsonSchemaWriter
    {
        protected override void VisitConditionalIfClause(JsonSchemaConstraint condition)
        {
            writer.WriteStartObject(Keys.If);
            base.VisitConditionalIfClause(condition);
            writer.WriteEndObject();
        }

        protected override void VisitConditionalThenClause(JsonSchemaConstraint condition)
        {
            writer.WriteStartObject(Keys.Then);
            base.VisitConditionalThenClause(condition);
            writer.WriteEndObject();
        }

        protected override void VisitConditionalElseClause(JsonSchemaConstraint condition)
        {
            writer.WriteStartObject(Keys.Else);
            base.VisitConditionalElseClause(condition);
            writer.WriteEndObject();
        }

        protected internal override void VisitNot(JsonSchemaNot constraint)
        {
            writer.WriteStartObject(Keys.Not);
            base.VisitNot(constraint);
            writer.WriteEndObject();
        }
    }
}
