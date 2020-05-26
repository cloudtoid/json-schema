namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;
    using static Contract;

    public abstract class JsonSchemaArrayItems
    {
        protected internal abstract void Accept(JsonSchemaVisitor visitor);
    }

    public class JsonSchemaArraySingleItem : JsonSchemaArrayItems
    {
        public JsonSchemaArraySingleItem(
            JsonSchemaChildElement item)
        {
            Item = CheckValue(item, nameof(item));
        }

        public virtual JsonSchemaChildElement Item { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitArraySingleItem(this);
    }

    public class JsonSchemaArrayArrayItems : JsonSchemaArrayItems
    {
        public JsonSchemaArrayArrayItems(
            IReadOnlyCollection<JsonSchemaChildElement> items,
            JsonSchemaChildElement? additionalItems)
        {
            Items = CheckValue(items, nameof(items));
            AdditionalItems = additionalItems;
        }

        public virtual IReadOnlyCollection<JsonSchemaChildElement> Items { get; }

        public virtual JsonSchemaChildElement? AdditionalItems { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitArrayArrayItems(this);
    }
}
