namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;
    using static Contract;

    // the following restrictions can only be applied to Json values of type array
    public class JsonSchemaArray : JsonSchemaConstraint
    {
        public JsonSchemaArray(
            JsonSchemaChildElement? item = null,
            JsonSchemaChildElement? contains = null,
            int? minsItems = null,
            int? maxItems = null,
            bool? uniqueItems = null)
        {
            if (item != null)
                Items = new JsonSchemaArraySingleItem(item);

            Contains = contains;
            MinItems = minsItems is null ? default : CheckNonNegative(minsItems.Value, nameof(minsItems));
            MaxItems = maxItems is null ? default : CheckNonNegative(maxItems.Value, nameof(maxItems));
            UniqueItems = uniqueItems;
        }

        public JsonSchemaArray(
            IReadOnlyList<JsonSchemaChildElement> items,
            JsonSchemaChildElement? additionalItems = null,
            JsonSchemaChildElement? contains = null,
            int? minsItems = null,
            int? maxItems = null,
            bool? uniqueItems = null)
        {
            Items = new JsonSchemaArrayArrayItems(items, additionalItems);
            Contains = contains;
            MinItems = minsItems is null ? default : CheckNonNegative(minsItems.Value, nameof(minsItems));
            MaxItems = maxItems is null ? default : CheckNonNegative(maxItems.Value, nameof(maxItems));
            UniqueItems = uniqueItems;
        }

        /// <summary>
        /// Gets the minimum number of items in the array.
        /// An array is valid against this value, if the number of items it contains is greater than, or equal to, this value.
        /// This value must be a non-negative integer.
        /// </summary>
        public virtual int? MinItems { get; }

        /// <summary>
        /// Gets the maximum number of items in the array.
        /// An array is valid against this value, if the number of items it contains is less than, or equal to, this value.
        /// This value must be a non-negative integer.
        /// </summary>
        public virtual int? MaxItems { get; }

        /// <summary>
        /// Gets the value that indicates all items in this array must be unique.
        /// </summary>
        public virtual bool? UniqueItems { get; }

        /// <summary>
        /// Gets a Json schema element.
        /// An array is valid against this element if at least one item is valid against the schema defined by this value.
        /// The value of this keyword must be a valid Json schema element (object or boolean).
        /// </summary>
        public virtual JsonSchemaChildElement? Contains { get; }

        /// <summary>
        /// Gets the item constraints.
        /// An array is valid against this value if items are valid against the corresponding schemas provided here. This value can be
        /// <list type="bullet">
        /// <item>a valid Json schema element (object or boolean), then every item must be valid against this schema. In this case,
        /// this property will be set to an instance of <see cref="JsonSchemaArraySingleItem"/></item>
        /// <item>an array of valid Json schemas, then each item must be valid against the schema defined at the same position(index).
        /// Items that don’t have a corresponding position (array contains 5 items and this value only has 3) will be considered valid,
        /// unless the additionalItems keyword is present - which will decide the validity. In this case, this property will be set to
        /// an instance of <see cref="JsonSchemaArrayArrayItems"/></item>
        /// </list>
        /// </summary>
        public JsonSchemaArrayItems? Items { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitArray(this);
    }

    public abstract class JsonSchemaArrayItems
    {
        protected internal abstract void Accept(JsonSchemaVisitor visitor);
    }

    public sealed class JsonSchemaArraySingleItem : JsonSchemaArrayItems
    {
        internal JsonSchemaArraySingleItem(JsonSchemaChildElement item)
        {
            Item = CheckValue(item, nameof(item));
        }

        public JsonSchemaChildElement Item { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitArraySingleItem(this);
    }

    public sealed class JsonSchemaArrayArrayItems : JsonSchemaArrayItems
    {
        internal JsonSchemaArrayArrayItems(
            IReadOnlyList<JsonSchemaChildElement> items,
            JsonSchemaChildElement? additionalItems = null)
        {
            Items = CheckValue(items, nameof(items));
            AdditionalItems = additionalItems;
        }

        public IReadOnlyList<JsonSchemaChildElement> Items { get; }

        public JsonSchemaChildElement? AdditionalItems { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitArrayArrayItems(this);
    }
}
