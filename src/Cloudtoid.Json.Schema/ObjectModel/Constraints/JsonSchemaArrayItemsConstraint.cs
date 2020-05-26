namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;
    using static Contract;

    // the following restrictions can only be applied to json values of type array
    public abstract class JsonSchemaArrayItemsConstraint : JsonSchemaConstraint
    {
    }

    public class JsonSchemaArraySingleItemConstraint : JsonSchemaArrayItemsConstraint
    {
        public JsonSchemaArraySingleItemConstraint(
            JsonSchemaElement item)
        {
            Item = CheckValue(item, nameof(item));
        }

        public JsonSchemaElement Item { get; }
    }

    public class JsonSchemaArrayArrayItemConstraint : JsonSchemaArrayItemsConstraint
    {
        public JsonSchemaArrayArrayItemConstraint(
            IReadOnlyCollection<JsonSchemaElement> items,
            JsonSchemaElement? additionalItems)
        {
            Items = CheckValue(items, nameof(items));
            AdditionalItems = additionalItems;
        }

        public IReadOnlyCollection<JsonSchemaElement> Items { get; }

        public JsonSchemaElement? AdditionalItems { get; }
    }
}
