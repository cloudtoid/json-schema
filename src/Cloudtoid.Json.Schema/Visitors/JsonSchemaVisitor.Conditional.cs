namespace Cloudtoid.Json.Schema
{
    public abstract partial class JsonSchemaVisitor
    {
        protected internal virtual void VisitIf(JsonSchemaIf constraint)
        {
            // visit self
            VisitConstraint(constraint);

            // visit children

            Visit(constraint.If);
            Visit(constraint.Then);

            if (constraint.Else != null)
                Visit(constraint.Else);
        }

        protected internal virtual void VisitNot(JsonSchemaNot constraint)
        {
            // visit self
            VisitConstraint(constraint);

            // visit children
            Visit(constraint.Not);
        }
    }
}
