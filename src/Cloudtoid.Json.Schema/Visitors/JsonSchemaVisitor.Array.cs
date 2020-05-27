namespace Cloudtoid.Json.Schema
{
    public abstract partial class JsonSchemaVisitor
    {
        protected virtual void Visit(JsonSchemaArrayItems items)
            => items.Accept(this);

        protected internal virtual void VisitArray(JsonSchemaArray constraint)
        {
            // visit self
            VisitConstraint(constraint);

            // visit children

            if (constraint.Contains != null)
                VisitArrayContains(constraint.Contains);

            if (constraint.Items != null)
                VisitArrayItems(constraint.Items);
        }

        protected virtual void VisitArrayContains(JsonSchemaSubSchema constraint)
            => Visit(constraint);

        protected virtual void VisitArrayItems(JsonSchemaArrayItems items)
            => Visit(items);

        protected internal virtual void VisitArraySingleItem(JsonSchemaArraySingleItem item)
            => Visit(item.Item);

        protected internal virtual void VisitArrayArrayItems(JsonSchemaArrayArrayItems items)
        {
            foreach (var item in items.Items)
                VisitArrayArrayItem(item);

            if (items.AdditionalItems != null)
                VisitArrayAdditionalItems(items.AdditionalItems);
        }

        protected internal virtual void VisitArrayArrayItem(JsonSchemaSubSchema item)
            => Visit(item);

        protected virtual void VisitArrayAdditionalItems(JsonSchemaSubSchema items)
            => Visit(items);
    }
}
