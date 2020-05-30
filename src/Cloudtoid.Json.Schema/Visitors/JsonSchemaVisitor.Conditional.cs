namespace Cloudtoid.Json.Schema
{
    public abstract partial class JsonSchemaVisitor
    {
        protected internal virtual void VisitConditional(JsonSchemaConditional constraint)
        {
            // visit self
            VisitConstraint(constraint);

            // visit children

            if (constraint.If is null)
                return;

            if (constraint.Then is null && constraint.Else is null)
                return;

            VisitConditionalIfClause(constraint.If);

            if (constraint.Then != null)
                VisitConditionalThenClause(constraint.Then);

            if (constraint.Else != null)
                VisitConditionalElseClause(constraint.Else);
        }

        protected virtual void VisitConditionalIfClause(JsonSchemaConstraint condition)
            => Visit(condition);

        protected virtual void VisitConditionalThenClause(JsonSchemaConstraint condition)
            => Visit(condition);

        protected virtual void VisitConditionalElseClause(JsonSchemaConstraint condition)
            => Visit(condition);

        protected internal virtual void VisitNot(JsonSchemaNot constraint)
        {
            // visit self
            VisitConstraint(constraint);

            // visit children
            Visit(constraint.Not);
        }
    }
}
