namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;
    using static Contract;

    // the following restrictions can only be applied to Json values of type array
    public class JsonSchemaArray : JsonSchemaConstraint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaArray"/> class.
        /// </summary>
        /// <param name="item">All array elements are validated against this schema element.</param>
        /// <param name="minsItems">The minimum number of items in the array instance.</param>
        /// <param name="maxItems">The maximum number of items in the array instance.</param>
        /// <param name="uniqueItems">If this keyword has boolean value <see langword="false"/>, the instance validates successfully.
        ///     If it has boolean value <see langword="true"/>, the instance validates successfully if all of its elements are unique.</param>
        /// <param name="contains">The schema element that should be found in the array instance.</param>
        /// <param name="minContains">The minimum number of contains matches in the array instance.</param>
        /// <param name="maxContains">The maximum number of contains matches in the array instance.</param>
        public JsonSchemaArray(
            JsonSchemaChildElement? item = null,
            uint? minsItems = null,
            uint? maxItems = null,
            bool? uniqueItems = null,
            JsonSchemaChildElement? contains = null,
            uint? minContains = null,
            uint? maxContains = null)
        {
            if (item != null)
                Items = new JsonSchemaArraySingleItem(item);

            MinItems = minsItems;
            MaxItems = maxItems;
            UniqueItems = uniqueItems;
            Contains = contains;
            MinContains = minContains;
            MaxContains = maxContains;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaArray"/> class.
        /// </summary>
        /// <param name="items">Each element of the array instance validates against the schema at the same position, if any.</param>
        /// <param name="additionalItems">Each element of the array past the length of <paramref name="items"/> is validated against this schema element.</param>
        /// <param name="minsItems">The minimum number of items in the array instance.</param>
        /// <param name="maxItems">The maximum number of items in the array instance.</param>
        /// <param name="uniqueItems">If this keyword has boolean value <see langword="false"/>, the instance validates successfully.
        ///     If it has boolean value <see langword="true"/>, the instance validates successfully if all of its elements are unique.</param>
        /// <param name="contains">The schema element that should be found in the array instance.</param>
        /// <param name="minContains">The minimum number of contains matches in the array instance.</param>
        /// <param name="maxContains">The maximum number of contains matches in the array instance.</param>
        public JsonSchemaArray(
            IReadOnlyList<JsonSchemaChildElement> items,
            JsonSchemaChildElement? additionalItems = null,
            uint? minsItems = null,
            uint? maxItems = null,
            bool? uniqueItems = null,
            JsonSchemaChildElement? contains = null,
            uint? minContains = null,
            uint? maxContains = null)
        {
            Items = new JsonSchemaArrayArrayItems(items, additionalItems);
            MinItems = minsItems;
            MaxItems = maxItems;
            UniqueItems = uniqueItems;
            Contains = contains;
            MinContains = minContains;
            MaxContains = maxContains;
        }

        /// <summary>
        /// Gets the minimum number of items in the array instance.
        /// An array is valid against this value, if the number of items it contains is greater than, or equal to, this value.
        /// This value must be a non-negative integer.
        /// </summary>
        public virtual uint? MinItems { get; }

        /// <summary>
        /// Gets the maximum number of items in the array instance.
        /// An array is valid against this value, if the number of items it contains is less than, or equal to, this value.
        /// This value must be a non-negative integer.
        /// </summary>
        public virtual uint? MaxItems { get; }

        /// <summary>
        /// Gets the value that indicates if all items in this array must be unique.
        /// </summary>
        public virtual bool? UniqueItems { get; }

        /// <summary>
        /// Gets a Json schema element that should be found in the array instance.
        /// An array is valid against this element if at least one item is valid against the schema defined by this value.
        /// The value of this keyword must be a valid Json schema element (object or boolean).
        /// </summary>
        public virtual JsonSchemaChildElement? Contains { get; }

        /// <summary>
        /// Gets the minimum number of contains matches in the array instance.
        /// This value must be a non-negative integer.
        /// </summary>
        public virtual uint? MinContains { get; }

        /// <summary>
        /// Gets the maximum number of contains matches in the array instance.
        /// This value must be a non-negative integer.
        /// </summary>
        public virtual uint? MaxContains { get; }

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
